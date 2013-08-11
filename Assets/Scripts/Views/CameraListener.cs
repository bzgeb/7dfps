using UnityEngine;
using System.Collections;

[RequireComponent( typeof( Camera ) )]
public class CameraListener : MonoBehaviour
{
    Camera cam;
    void Start() {
        cam = GetComponent<Camera>();
    }

    void OnEnable() {
        EventManager.Register( "OnPlayerJoined", OnPlayerJoined );
        EventManager.Register( "OnPlayerQuit", OnPlayerQuit );
    }

    void OnDisable() {
        EventManager.Deregister( "OnPlayerJoined", OnPlayerJoined );
        EventManager.Deregister( "OnPlayerQuit", OnPlayerQuit );
    }

    public void OnPlayerJoined( params object[] args ) {
        cam.rect = new Rect( 0, 0.5f, 1, 0.5f );
    }

    public void OnPlayerQuit( params object[] args ) {
        cam.rect = new Rect( 0, 0, 1, 1 );
    }

    void Update() {
        if ( Input.GetKeyDown( KeyCode.I ) ) {
            OnPlayerJoined();
        }

        if ( Input.GetKeyDown( KeyCode.O ) ) {
            OnPlayerQuit();
        }
    }
}
