using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;

[System.Serializable]
public class ModifiedFiles : ScriptableObject
{
    [SerializeField]
    public List<FileMod> addedFiles;
    [SerializeField]
    public List<string> deletedFiles;

    public void AddFile( string src, string dst ) {
        bool duplicate = false;

        if ( addedFiles == null ) {
            addedFiles = new List<FileMod>();
        }

        foreach ( FileMod fileMod in addedFiles ) {
            if ( fileMod.sourcePath == src ) {
                Debug.Log("Already there"); 
                duplicate = true;
            }
        }

        if ( !duplicate ) {
            FileMod fileModification = new FileMod();
            fileModification.sourcePath = src;
            fileModification.destinationPath = dst;
            
            addedFiles.Add( fileModification );
        }
    }

    public void DeleteFile( string dst ) {
        if ( deletedFiles == null ) {
            deletedFiles = new List<string>();
        }

        deletedFiles.Add( dst );
    }

    static public ModifiedFiles GetModifiedFiles() {
        ModifiedFiles modifiedFiles;
        if ( !File.Exists( string.Format( "{0}/ModifiedFiles.asset", Application.dataPath ) ) ) {
            Debug.Log( "Not There" );

            modifiedFiles = ScriptableObject.CreateInstance<ModifiedFiles>();
            AssetDatabase.CreateAsset( modifiedFiles, "Assets/ModifiedFiles.asset" );
            AssetDatabase.SaveAssets();

        } else {
            modifiedFiles = (ModifiedFiles)AssetDatabase.LoadMainAssetAtPath( "Assets/ModifiedFiles.asset" );
        }

        return modifiedFiles;
    }
}


[System.Serializable]
public class FileMod
{
    [SerializeField]
    public string sourcePath;
    [SerializeField]
    public string destinationPath;
}
