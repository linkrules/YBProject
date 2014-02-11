/*
================================================================================
FileName    : DataCenter.cs
Description : load or save data from disk file, like xml , text, or other format
Date        : 2014-02-10
Author      : Linkrules
================================================================================
*/
using UnityEngine;
using System.Collections;
using System.Xml;

public class DataCenter {

    static public XmlDocument LoadDataFromXmlFile( string dataPath ) {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load( dataPath );
        // decrypt
        return xmlDoc;
    }

    static public void SaveDataToXmlFile( string dataPath, XmlDocument xmlDoc ) {
        // encrypt
        xmlDoc.Save( dataPath );
    }

    
}
