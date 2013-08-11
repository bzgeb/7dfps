using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections;
using System.Threading;

public class RefreshExternal : ScriptableWizard
{
    static bool disabled;
    public string pathToExternalFolder = @"C:/Users/Bronson/Dropbox/THE TATIS CHRONICLES/7DFPS";
    public string pathToLocalExternalFolder = string.Format( "{0}/External", Application.dataPath, "External" );

    [MenuItem( "GameObject/Refresh External References" )]
    static void CreateWizard() {
        if ( disabled ) {
            ScriptableWizard.DisplayWizard<RefreshExternal>( "Refresh Externals", "Busy! Go Away!" );
        } else {
            ScriptableWizard.DisplayWizard<RefreshExternal>( "Refresh Externals", "Push Changes" );
        }
    }

    void OnWizardCreate() {
        if ( disabled ) {
            Debug.LogError( "I'm Busy!" );
            return;
        }
        string folderName = "External";
        string dstFolder = System.IO.Path.Combine( pathToExternalFolder, folderName );
        if ( !System.IO.Directory.Exists( dstFolder ) ) {
            System.IO.Directory.CreateDirectory( dstFolder );
        }

        Thread thread = new Thread( x => {
            disabled = true;
            CopyDir( pathToLocalExternalFolder, dstFolder );
            Debug.Log( "External Push Complete" );
            disabled = false;
        } );
        thread.Start();
    }

    static void CopyDir( string src, string dst ) {
        string[] files = System.IO.Directory.GetFiles( src );
        foreach ( string file in files ) {
            string fileName = System.IO.Path.GetFileName( file );
            string destFile = System.IO.Path.Combine( dst, fileName );
            System.IO.File.Copy( file, destFile, true );
        }

        string[] directories = System.IO.Directory.GetDirectories( src );
        foreach ( string dir in directories ) {
            string dirName = System.IO.Path.GetFileNameWithoutExtension( dir );
            string destDir = System.IO.Path.Combine( dst, dirName );
            if ( !System.IO.Directory.Exists( destDir ) ) {
                System.IO.Directory.CreateDirectory( destDir );
            }
            CopyDir( dir, destDir );
        }
    }

    void OnWizardUpdate() {
    }

    // When the user pressed the "Apply" button OnWizardOtherButton is called.
    void OnWizardOtherButton() {
    }
}
