/*
================================================================================
FileName    : DebugTool
Description : display the debug information on the screnn
Date        : 2014-01-23
Author      : Linkrules
================================================================================
*/
using UnityEngine;
using System.Collections;

namespace GameTools {

    public class DebugTool : MonoBehaviour {

        private string debugInfo = "";

        public void Debug(string debugStr) {
            debugInfo += debugStr;
        }

        public void DebugSigleLine(string debugStr) {
            debugInfo = "";
            debugInfo = debugStr;
        }


        void OnGUI() {
            GUILayout.Label("<color=red>" + debugInfo + "</color>");
        }
    }

}
