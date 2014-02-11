/*
================================================================================
FileName    : Energy.cs 
Description : energy model , parse and assume energy data from xmldoc or other method, change energy value
Date        : 2014-02-10
Author      : Linkrules
================================================================================
*/
using UnityEngine;
using System.Collections;
using System.Xml;

public enum EnergyChange_t {
    Use,
    Add,
}


public class Energy{
    public int energyID              = 0;
    public int energyPool            = 0;
    public int energy                = 0;
    public int weaponEnergyBaseRate  = 0;
    public int defenseEnergyBaseRate = 0;

    public void EnergyInit( bool isAI ) {
        if ( isAI ) {
            LoadEnergyDataFromXml( DataPath.aiEnergyDataFilePath + energyID);
        } else {
            LoadEnergyDataFromXml( DataPath.energyDataFilePath );
        }
    }

    public void LoadDataFromPlayerPrefs() {
        PlayerPrefs.SetInt( "EnergyPool", energyPool );
        PlayerPrefs.SetInt( "Energy", energy );
        PlayerPrefs.SetInt( "WeaponEnergyBaseRate", weaponEnergyBaseRate );
        PlayerPrefs.SetInt( "DefenseEnergyBaseRate", defenseEnergyBaseRate );
    }

    public void SaveDataToPlayerPrefs() {
        energyPool = PlayerPrefs.GetInt( "EnergyPool" );
        energy = PlayerPrefs.GetInt( "Energy" );
        weaponEnergyBaseRate = PlayerPrefs.GetInt( "WeaponEnergyBaseRate" );
        defenseEnergyBaseRate = PlayerPrefs.GetInt( "DefenseEnergyBaseRate" );
    }


    public void LoadEnergyDataFromXml( string energyDataPath) {
        XmlDocument xmlDoc = DataCenter.LoadDataFromXmlFile( energyDataPath );
        if ( xmlDoc != null ) {
            XmlNodeList nodeList = xmlDoc.SelectSingleNode( "root" ).ChildNodes;
            for ( int nodeIndex = 0; nodeIndex < nodeList.Count; ++nodeIndex ) {
                switch ( nodeList[nodeIndex].Name ) {
                    case "EnergyPool":
                        energyPool = int.Parse( nodeList[nodeIndex].InnerText );
                        break;
                    case "Energy":
                        energy = int.Parse( nodeList[nodeIndex].InnerText );
                        break;
                    case "DefenseEnergyBaseRate":
                        defenseEnergyBaseRate = int.Parse( nodeList[nodeIndex].InnerText );
                        break;
                    case "WeaponEnergyBaseRate":
                        weaponEnergyBaseRate = int.Parse( nodeList[nodeIndex].InnerText );
                        break;
                }
            }
        } else {
           
        }
    }


    public void SaveEnergyDataToXml() {
        XmlDocument xmlDoc = new XmlDocument();
        XmlElement root = xmlDoc.CreateElement( "root" );
        XmlElement item;

        item = xmlDoc.CreateElement( "EnergyPool" );
        item.InnerText = energyPool.ToString();
        root.AppendChild( item );

        item = xmlDoc.CreateElement( "Energy" );
        item.InnerText = energyPool.ToString();
        root.AppendChild( item );

        item = xmlDoc.CreateElement( "defenseEnergyBaseRate" );
        item.InnerText = defenseEnergyBaseRate.ToString();
        root.AppendChild( item );

        item = xmlDoc.CreateElement( "WeaponEnergyBaseRate" );
        item.InnerText = weaponEnergyBaseRate.ToString();
        root.AppendChild( item );

        DataCenter.SaveDataToXmlFile( DataPath.energyDataFilePath, xmlDoc );
    }


    public bool EnergyChange( EnergyChange_t energyChange, int changeValue ) {
        switch ( energyChange ) {
            case EnergyChange_t.Use:
                if ( energy < changeValue ) {
                    return false;
                }
                energy -= changeValue;
                break;
            case EnergyChange_t.Add:
                energy += changeValue;
                break;
        }
        return true;
    }


    public bool EnergyTransmit( ref int from, ref int to, int value ) {
        if ( from - value <= 0 ) {
            return false;
        }
        from -= value;
        to += value;
        return true;
    }

}
