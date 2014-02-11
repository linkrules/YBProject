using UnityEditor;
using UnityEngine;
using System.Collections;
using System.IO;
using System.Xml;

public class CoffeeTime : EditorWindow {
	
	private int coffeeID = 0;
	private Object oldTexture;
	private Object newTexture;
	private string oldTexturePath;
	private string newTexturePath;
	WWW www;

    /*
    private string datFileName = "";
    private string datFilePath = "";
	*/

	[MenuItem("Game Tool/Coffee Time V0.1 %k")]
	static void InitWindow () {
		EditorWindow.GetWindow<CoffeeTime>("Coffee Time");
	}
	
	void OnGUI () {
        
		GUILayout.BeginVertical ();
		if( coffeeID == 0 ) {
			if( GUILayout.Button("Replace Texture") ) {
				coffeeID = 1;
			}else if( GUILayout.Button ("Look Dat File") ) {
				coffeeID = 2;
            }
            else if( GUILayout.Button("Create Folders") ) {
				coffeeID = 3;
			}else if( GUILayout.Button ("Coffee 04") ) {
				coffeeID = 4;
			}
		}else{
			EasyWork( coffeeID );
		}
		
	}
	
	
	private void EasyWork (int cID) {
		switch ( cID ) {
		case 1:
			TextureReplace();
			break;
		case 2:
            DatFileLook();
			break;
		case 3:
            CreateProjectFolders();
            //CleanTheCoffee();
			break;
		case 4:
			
			break;
		}
		
		GUILayout.Space(50);
		if( GUILayout.Button( "Back To Choice" ) ) {
			CleanTheCoffee ();
		}
		
	}
	
	
	private void CleanTheCoffee () {
		// ------------------ Replace Texture ---------------------
        coffeeID = 0;
		oldTexture = null;
		newTexture = null;
		oldTexturePath = "";
		newTexturePath = "";
		// ------------------ Replace Texture ---------------------
		
	}
	
	
	/*
	 * <linkrules> [2013-10-26]
	 * Selecte source texture from unity , select new texture from disk , press Replace, you can take a coffee time
	 */
	private void TextureReplace () {
		GUILayout.BeginVertical ();
		
		// ---------------------------------------- Texture Replace -------------------------------------------
		GUILayout.BeginHorizontal ();
		GUILayout.Label("Old",GUILayout.Width(50));
		GUILayout.Label("New",GUILayout.Width(50));
		GUILayout.EndHorizontal ();
		
		GUILayout.BeginHorizontal ();
        
		oldTexture = EditorGUILayout.ObjectField(oldTexture,typeof(Texture), true, GUILayout.Width(50),GUILayout.Height(50));
        newTexture = EditorGUILayout.ObjectField(newTexture, typeof(Texture), true, GUILayout.Width(50), GUILayout.Height(50));
		oldTexturePath = AssetDatabase.GetAssetPath(oldTexture);
		
		GUILayout.BeginVertical ();
		if( GUILayout.Button("Import",GUILayout.Width(60),GUILayout.Height(20)) ) {
			newTexturePath = EditorUtility.OpenFilePanel("Please Selecte the New Texture","","png");
			if( newTexturePath != "" ) {
				www = new WWW("file:///" + newTexturePath);
				newTexture = www.texture;
			}
		}
		
		GUILayout.Label("",GUILayout.Height(5));
		
		if( GUILayout.Button("Replace",GUILayout.Width(60),GUILayout.Height(20)) ) {
			if( newTexturePath != "" && oldTexturePath != "") {
				byte[] newTextureData = www.texture.EncodeToPNG();
				File.WriteAllBytes(oldTexturePath,newTextureData);
				newTexture = null;
				newTexturePath = "";
				
			}else{
				Debug.Log ("COFFEE_TIME: You should select a texture!");
			}
		}
		AssetDatabase.Refresh ();
		GUILayout.EndVertical ();
		
		GUILayout.EndHorizontal ();
		// ---------------------------------------- Texture Replace -------------------------------------------

		GUILayout.EndVertical ();
		
	}

    
    // <linkrules> decrypte dat file by call XmlIO scripts
    private void DatFileLook() {
        /*
        GUILayout.BeginVertical();
        GUILayout.BeginHorizontal();
        GUILayout.Label("streammingAssets/",GUILayout.Width(120));
        datFilePath = GUILayout.TextField(datFilePath,GUILayout.Width(200));
        GUILayout.Label("/");
        GUILayout.EndHorizontal();
        
        GUILayout.BeginHorizontal();
        GUILayout.Label("DatFileName:",GUILayout.Width(120));
        datFileName = GUILayout.TextField(datFileName,GUILayout.Width(200));
        GUILayout.EndHorizontal();

        if( GUILayout.Button("Look At") ) {
            string path = XmlIO.GetDataPath() + datFilePath + "/" + datFileName + ".dat";
            if( File.Exists(path) ) {
                XmlDocument xmlDoc = XmlIO.LoadXML(datFilePath + "/", datFileName);
                string savePath = XmlIO.GetDataPath() + datFilePath + "/" + datFileName + ".xml";
                xmlDoc.Save(savePath);
                Debug.Log("Congratulations Boy, you look the encryped file success.");
                AssetDatabase.Refresh();
            }
            else {
                Debug.LogError("Error: File does not exists");
            }
        }

        GUILayout.EndVertical();
      */
    }
    

    // <linkrules> [2013-12-24] Create project folder , like Objects , Scripts , Textures, Materials etc..
    private string[] folderNames = {
                                       "Objects",
                                       "Scripts",
                                       "Textures",
                                       "Materials",
                                       "Editor",
                                       "Resources",
                                       "Scenes",
                                       "StreamingAssets",
                                       "Shader",
                                       "UI",
                                       "Terrains",
                                       "Prefabs"
                                   };
    private void CreateProjectFolders() {
        for( int f_index = 0; f_index < folderNames.Length; ++f_index ) {
            GUILayout.Label("Create Folder: " + folderNames[f_index]);
            Directory.CreateDirectory(Application.dataPath + "/" + folderNames[f_index]);
        }

        AssetDatabase.Refresh();
        CleanTheCoffee();
    }

                                   

	
}
