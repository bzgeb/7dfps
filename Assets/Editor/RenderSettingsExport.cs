using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class RenderSettingsExport {
 
    [MenuItem ("CONTEXT/RenderSettings/Export")]
    static void Export () {
        RenderSettingsObject obj = ScriptableObject.CreateInstance<RenderSettingsObject>();
        obj.ambientLight = RenderSettings.ambientLight;
        obj.flareStrength = RenderSettings.flareStrength;
        obj.fog = RenderSettings.fog;
        obj.fogColor = RenderSettings.fogColor;
        obj.fogDensity = RenderSettings.fogDensity;
        obj.fogEndDistance = RenderSettings.fogEndDistance;
        obj.fogMode = RenderSettings.fogMode;
        obj.fogStartDistance = RenderSettings.fogStartDistance;
        obj.haloStrength = RenderSettings.haloStrength;
        obj.skybox = RenderSettings.skybox;

        AssetDatabase.CreateAsset( obj, "Assets/RenderSettingsObject.asset" );
        AssetDatabase.SaveAssets();
    }

    [MenuItem ("CONTEXT/RenderSettings/Import")]
    static void Import () {
        if ( !File.Exists(string.Format("{0}/RenderSettingsObject.asset", Application.dataPath ) ) ) {
            Debug.Log("Not There");
            return;
        }
        RenderSettingsObject obj = (RenderSettingsObject)AssetDatabase.LoadMainAssetAtPath("Assets/RenderSettingsObject.asset");
        RenderSettings.ambientLight = obj.ambientLight;
        RenderSettings.flareStrength = obj.flareStrength;
        RenderSettings.fog = obj.fog;
        RenderSettings.fogColor = obj.fogColor;
        RenderSettings.fogDensity = obj.fogDensity;
        RenderSettings.fogEndDistance = obj.fogEndDistance;
        RenderSettings.fogMode = obj.fogMode;
        RenderSettings.fogStartDistance = obj.fogStartDistance;
        RenderSettings.haloStrength = obj.haloStrength;
        RenderSettings.skybox = obj.skybox;
    }
}
