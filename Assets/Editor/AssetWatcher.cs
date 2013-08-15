using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;


public class AssetWatcher : AssetPostprocessor
{
    private static void OnPostprocessAllAssets( string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromPath ) {
        string pathToLocalExternalFolder = string.Format( "Assets/External" );
        string pathToExternalFolder = EditorPrefs.GetString( RefreshExternal.externalFolderKey );

        foreach ( string asset in importedAssets ) {
            if ( asset.IndexOf( pathToLocalExternalFolder ) != -1 ) {
                OnNewImport( asset.Substring( asset.IndexOf( "External" ) ).Replace( "External/", "" ), asset, pathToExternalFolder );
            }
            Debug.Log( "Imported: " + asset );
        }

        foreach ( string asset in deletedAssets ) {
            if ( asset.IndexOf( pathToLocalExternalFolder ) != -1 ) {
                OnDelete( asset.Substring( asset.IndexOf( "External" ) ).Replace( "External/", "" ), pathToExternalFolder );
            } else {
                Debug.Log( "Deleted: " + asset );
            }
        }

        for ( int i = 0; i < movedAssets.Length; i++ ) {
            string src = movedFromPath[i];
            if ( src.IndexOf( pathToLocalExternalFolder ) != -1 ) {
                OnDelete( src.Substring( src.IndexOf( "External" ) ).Replace( "External/", "" ), pathToExternalFolder );
            }
            Debug.Log( "Moved: from " + movedFromPath[i] + " to " + movedAssets[i] );
        }
    }

    static void OnNewImport( string relativePath, string path, string externalPath ) {
        string externalFile = Path.Combine( externalPath, relativePath );
        Debug.Log( string.Format( "Imported: {0} now Creating: {1}", relativePath, externalFile ) );

        ModifiedFiles modifiedFiles = ModifiedFiles.GetModifiedFiles();

        if ( File.Exists( externalFile ) ) {
            if ( File.GetLastWriteTime( externalFile ) < File.GetLastWriteTime( path ) ) {
                modifiedFiles.AddFile( path, externalFile );
                AssetDatabase.SaveAssets();
                //File.Copy( path, externalFile );
            }
        } else {
            modifiedFiles.AddFile( path, externalFile );
            AssetDatabase.SaveAssets();
            //File.Copy( path, externalFile );
        }
    }

    static void OnDelete( string relativePath, string externalPath ) {
        string externalFile = Path.Combine( externalPath, relativePath );
        Debug.Log( string.Format( "Deleted: {0} now Deleting: {1}", relativePath, externalFile ) );

        ModifiedFiles modifiedFiles = ModifiedFiles.GetModifiedFiles();

        if ( File.Exists( externalFile ) ) {
            modifiedFiles.DeleteFile( externalFile );
            AssetDatabase.SaveAssets();
        }
    }

    //static void OnMove( string src, string dst ) {

    //}
}
