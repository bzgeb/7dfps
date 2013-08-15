using UnityEngine;
using System.Collections;

public class Homebase : MonoBehaviour {
    void OnClick( object[] args ) {
        GameObject clicker = (GameObject)args[0];
        PlayerController playerController = clicker.GetComponent<PlayerController>();

        if ( playerController == null ) {
            return;
        }

        if ( !playerController.HoldingObj ) {
            return;
        }


        Pickup obj = playerController.ObjHeld;

        Debug.Log( "Placed an obj: " + obj.name );
        playerController.SendMessage( "Drop" );

        EventManager.Push( "OnStashedObject" );

        Destroy( obj.gameObject );
    }
}
