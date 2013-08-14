using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public class Watcher {
    //[NonSerialized]
    //static FileSystemWatcher watcher;

    //[MenuItem("GameObject/Start File Watcher")]
    //static void InitWatcher() {
    //    string pathToExternalFolder = EditorPrefs.GetString( RefreshExternal.externalFolderKey );
    //    string pathToLocalExternalFolder = string.Format( "{0}/External/", Application.dataPath, "External" );

    //    watcher = new FileSystemWatcher();
    //    watcher.Path = pathToLocalExternalFolder;
    //    watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
    //    watcher.IncludeSubdirectories = true;
    //    watcher.Filter = "*.*";

    //    //watcher.Changed += new FileSystemEventHandler( OnChanged );
    //    watcher.Created += new FileSystemEventHandler( OnCreated );
    //    watcher.Deleted += new FileSystemEventHandler( OnDeleted );
    //    watcher.Renamed += new RenamedEventHandler( OnRenamed );

    //    watcher.EnableRaisingEvents = true;
    //}

    //private static void OnChanged( object source, FileSystemEventArgs e ) {
    //    // Specify what is done when a file is changed, created, or deleted.
    //    if ( Path.GetExtension( e.FullPath ) == ".meta" ) {
    //        return;
    //    }

    //    Debug.Log( "File: " + e.FullPath + " " + e.ChangeType );
    //}

    //private static void OnCreated( object source, FileSystemEventArgs e ) {
    //    if ( Path.GetExtension( e.FullPath ) == ".meta" ) {
    //        return;
    //    }

    //    Debug.Log( "File: " + e.FullPath + " created" );
    //}

    //private static void OnDeleted( object source, FileSystemEventArgs e ) {
    //    if ( Path.GetExtension( e.FullPath ) == ".meta" ) {
    //        return;
    //    }

    //    Debug.Log( "File: " + e.FullPath + " deleted" );
    //}

    //private static void OnRenamed( object source, RenamedEventArgs e ) {
    //    // Specify what is done when a file is renamed.
    //    if ( Path.GetExtension( e.FullPath ) == ".meta" ) {
    //        return;
    //    }
    //    Debug.Log( string.Format( "File: {0} renamed to {1}", e.OldFullPath, e.FullPath ) );
    //}

    //private static void OnFileDeleted( string path ) {
    //    string relativePath = path.Substring( path.IndexOf( "External" ) );
    //    Debug.Log( "Relative Path: " + relativePath );
    //    //deletedFiles.Add( path );
    //}
}
