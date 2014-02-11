using UnityEngine;
using System.Collections;
using GameTools;

public class GlobalManager {

    #region Global GameObject
    static private GameObject _globalGameObject = null;
    public GameObject globalGameObject {
        get {
            return _globalGameObject;
        }
    }
    #endregion

    #region Debug Tool
    static private DebugTool _debugTool = null;
    public DebugTool debugTool {
        get {
            return _debugTool;
        }
    }
    #endregion

    #region Globel Game Control
    static private GlobalGameControl _globalGameControl = null;
    public GlobalGameControl globalGameControl {
        get {
            return _globalGameControl;
        }
    }

    #endregion

    #region Main
    static private GlobalManager _instance = null;
    static public GlobalManager instance {
        get {
            if( _instance == null ) {
                _instance = new GlobalManager();

                // global game control
                _globalGameControl = new GlobalGameControl();

                // init global GameObject
                _globalGameObject = new GameObject();
                _globalGameObject.name = "GlobalGameObject";
                _debugTool = _globalGameObject.AddComponent<DebugTool>();
            }
            return _instance;
        }
    }
    

    #endregion




}
