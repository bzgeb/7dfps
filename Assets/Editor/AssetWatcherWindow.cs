using UnityEngine;
using UnityEditor;
using System.Collections;

public class AssetWatcherWindow : EditorWindow {

    ModifiedFiles modifiedFiles;

    [MenuItem( "Window/Asset Watch Window" )]
    static void Init() {
        AssetWatcherWindow window = (AssetWatcherWindow)EditorWindow.GetWindow( typeof( AssetWatcherWindow ) );
    }

    void OnGUI() {
        ModifiedFiles modifiedFiles = ModifiedFiles.GetModifiedFiles();
        if ( modifiedFiles.addedFiles == null || modifiedFiles.addedFiles.Count < 1 ) {
            GUILayout.BeginVertical();
            GUILayout.Label( "No added files" );
            GUILayout.EndVertical();
        } else {
            GUILayout.BeginVertical();

            foreach ( FileMod modification in modifiedFiles.addedFiles ) {
                GUILayout.BeginHorizontal();
                GUILayout.Label( modification.sourcePath );
                if ( GUILayout.Button( "Discard" ) ) {
                    Debug.Log( "This is supposed to discard" );
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.Button( "Push Changes" );
            GUILayout.EndVertical();
        }

        if ( modifiedFiles.deletedFiles == null || modifiedFiles.deletedFiles.Count < 1 ) {
            GUILayout.BeginVertical();
            GUILayout.Label( "No deleted files" );
            GUILayout.EndVertical();
        } else {
            GUILayout.BeginVertical();

            foreach ( string deletedFile in modifiedFiles.deletedFiles ) {
                GUILayout.BeginHorizontal();
                GUILayout.Label( deletedFile );
                if ( GUILayout.Button( "Discard" ) ) {
                    Debug.Log( "This is supposed to discard" );
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.Button( "Push Changes" );
            GUILayout.EndVertical();
        }
    }
}
