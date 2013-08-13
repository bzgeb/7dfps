using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections;

public class ReplaceShit : ScriptableWizard
{
    [MenuItem("GameObject/--Replace Shit")]
    static void CreateWizard() {
        ScriptableWizard.DisplayWizard( "Replace Shit", typeof(ReplaceShit), "Replace" );
    }

    void Apply( Transform t ) {
        string dataPath = Application.dataPath;
        string basePath = "/Prefabs/";
        string[] folders = {"Plants"};

        // Collect children
        if ( t == null ) {
            return;
        }

        if ( t.childCount > 0 ) {
            Transform[] children = new Transform[t.childCount];
            for ( int i = 0; i < t.childCount; ++i ) {
                Apply( t.GetChild(i) );
            }

            // Apply to children
            foreach( Transform child in children ) {
                Apply( child );
            }
        }

        foreach ( string folder in folders ) {
            string objectName = t.gameObject.name;

            int postFixLocation = objectName.LastIndexOf("_");
            if ( postFixLocation == -1 ) {
                postFixLocation = 0; 
            }
            string trimmedObjectName = objectName.Substring( 0, postFixLocation );

            string filePath = basePath + folder + "/" + objectName + ".prefab";
            string altFilePath = basePath + folder + "/" + trimmedObjectName + ".prefab";
            string thirdAltFilePath = basePath + folder + "/" + trimmedObjectName + "_" + ".prefab";

            GameObject prefab = null;
            if ( File.Exists( dataPath + filePath ) ) {
                Debug.Log( "Exists: " + filePath );
                prefab = AssetDatabase.LoadAssetAtPath( "Assets" + filePath, typeof(GameObject) ) as GameObject;
            } else if ( File.Exists( dataPath + altFilePath )) {
                Debug.Log( "Alt Exists: " + altFilePath );
                prefab = AssetDatabase.LoadAssetAtPath( "Assets" + altFilePath, typeof(GameObject) ) as GameObject;
            } else if ( File.Exists( dataPath + thirdAltFilePath ) ) {
                Debug.Log( "Third Alt Exists: " + altFilePath );
                prefab = AssetDatabase.LoadAssetAtPath( "Assets" + thirdAltFilePath, typeof(GameObject) ) as GameObject;
            }

            if ( prefab != null ) {
                Debug.Log( "Replacing" );
                DoReplace( t, prefab );
                break;
            }
        }
    }

    void DoReplace( Transform t, GameObject prefab ) {
        // Undo.RegisterSceneUndo("Replace Selection");
        GameObject g = (GameObject)PrefabUtility.InstantiatePrefab( prefab );
        Transform newTransform = g.transform;
        Debug.Log("Parent: " + t.parent);
        newTransform.parent = t.parent;
        newTransform.localPosition = t.localPosition;
        newTransform.localScale = t.localScale;
        newTransform.localRotation = t.localRotation;

        DestroyImmediate( t.gameObject );
    }

    void OnWizardCreate() {
        Transform[] transforms = Selection.GetTransforms(SelectionMode.TopLevel | SelectionMode.OnlyUserModifiable);

        foreach( Transform t in transforms ) {
            Apply( t );
        }
 
 
        // Transform[] transforms = Selection.GetTransforms(
        //     SelectionMode.TopLevel | SelectionMode.OnlyUserModifiable);
 
        // foreach (Transform t in transforms) {
        //     GameObject g;
            // PrefabType pref = EditorUtility.GetPrefabType(replacement);
 
        //     if (pref == PrefabType.Prefab || pref == PrefabType.ModelPrefab) {
        //         g = (GameObject)EditorUtility.InstantiatePrefab(replacement);
        //     } else {
        //         g = (GameObject)Editor.Instantiate(replacement);
        //     }
 
        //     Transform gTransform = g.transform;
        //     gTransform.parent = t.parent;
        //     g.name = replacement.name;
        //     gTransform.localPosition = t.localPosition;
        //     gTransform.localScale = t.localScale;
        //     gTransform.localRotation = t.localRotation;
        // }
 
        // if (!keep) {
        //     foreach (GameObject g in Selection.gameObjects) {
        //         GameObject.DestroyImmediate(g);
        //     }
        // }
    }
}
