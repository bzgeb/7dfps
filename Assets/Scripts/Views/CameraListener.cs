using UnityEngine;
using System.Collections;

[RequireComponent( typeof( Camera ) )]
public class CameraListener : MonoBehaviour
{
    Camera cam;
    bool isSplit;
    public Player player;
    void Start() {
        cam = GetComponent<Camera>();

    }

    void OnEnable() {
        EventManager.Register( "OnPlayerJoined", OnPlayerJoined );
        EventManager.Register( "OnPlayerQuit", OnPlayerQuit );
        EventManager.Register( "DispatchPlayerCount", OnDispatchPlayerCount );
    }

    void OnDisable() {
        EventManager.Deregister( "OnPlayerJoined", OnPlayerJoined );
        EventManager.Deregister( "OnPlayerQuit", OnPlayerQuit );
        EventManager.Deregister( "DispatchPlayerCount", OnDispatchPlayerCount );
    }

    void OnDispatchPlayerCount( params object[] args ) {
        int count = (int)args[0];

        if ( count > 1 ) {
            SplitScreen();
        }
    }

    void SplitScreen() {
        if ( player.index == PlayerIndex.One ) {
            cam.rect = new Rect( 0, 0.5f, 1, 0.5f );
        } else if ( player.index == PlayerIndex.Two ) {
            cam.rect = new Rect( 0, 0f, 1, 0.5f );
        }       

        isSplit = true;
    }

    void MergeScreen() {
        cam.rect = new Rect( 0, 0, 1, 1 );

        isSplit = false;
    }

    public void OnPlayerJoined( params object[] args ) {
        SplitScreen();
    }

    public void OnPlayerQuit( params object[] args ) {
        MergeScreen();
    }

    void LateUpdate() {
        EventManager.Push( "RequestPlayerCount" );
        if ( isSplit ) {
            cam.fov = 30;
        } else {
            cam.fov = 60;
        }
    }
}
