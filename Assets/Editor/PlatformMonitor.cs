using UnityEngine;
using UnityEditor;
using System.Collections;

public class PlatformMonitor {
    static BuildTarget cachedPlatform;

    static PlatformMonitor() {
        //cachedPlatform = EditorUserBuildSettings.activeBuildTarget;
        // EditorApplication.update += Update;
        //EditorUserBuildSettings.activeBuildTargetChanged += OnChangedPlatform;
    } 

    static void Update() {
    //     if ( EditorUserBuildSettings.activeBuildTarget != cachedPlatform ) {
    //         OnChangedPlatform();
    //         cachedPlatform = EditorUserBuildSettings.activeBuildTarget;
    //     }
    }

    static void OnChangedPlatform() {
        Debug.Log( "Changed Platform to " + EditorUserBuildSettings.activeBuildTarget );
        GameObject go = GameObject.Find("Plane");

        if ( cachedPlatform == BuildTarget.StandaloneOSXIntel || cachedPlatform == BuildTarget.StandaloneOSXIntel64 || cachedPlatform == BuildTarget.StandaloneOSXUniversal ) {
            DestroyOSXStuff( go );
        } else if ( cachedPlatform == BuildTarget.StandaloneWindows || cachedPlatform == BuildTarget.StandaloneWindows64 ) {
            DestroyWindowsStuff( go );
        }

        if ( EditorUserBuildSettings.activeBuildTarget == BuildTarget.StandaloneWindows || EditorUserBuildSettings.activeBuildTarget == BuildTarget.StandaloneWindows64 ) {
            AddWindowsStuff( go );
        } else if ( EditorUserBuildSettings.activeBuildTarget == BuildTarget.StandaloneOSXIntel || EditorUserBuildSettings.activeBuildTarget == BuildTarget.StandaloneOSXIntel64 || EditorUserBuildSettings.activeBuildTarget == BuildTarget.StandaloneOSXUniversal ) {
            AddOSXStuff( go );
        }

        cachedPlatform = EditorUserBuildSettings.activeBuildTarget;
    }

    static void DestroyOSXStuff( GameObject go ) {
        // GameObject.DestroyImmediate( go.GetComponent<SomethingOSX>() );
    }

    static void DestroyWindowsStuff( GameObject go ) {
        // GameObject.DestroyImmediate( go.GetComponent<SomethingWindows>() );
    }

    static void AddOSXStuff( GameObject go ) {
        // go.AddComponent<SomethingOSX>();
    }

    static void AddWindowsStuff( GameObject go ) {
        // go.AddComponent<SomethingWindows>();
    }
}
