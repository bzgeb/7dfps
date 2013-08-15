using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {
    public GameObject objectToPickup;
    public bool isHeld;
    // public Player playerModel;

    void Awake() {
        gameObject.tag = "Clickable";
        isHeld = false;
    }

    void OnClick( object[] args ) {
        GameObject clicker = (GameObject)args[0];
        GameObject pickupParent = (GameObject)args[1];
        Take( pickupParent );
        clicker.SendMessage( "Pickup", this );
    }

    void Update() {
        // if ( isHeld ) {
        //     if ( playerModel.GetPickupButton() ) {
        //         Drop();
        //     }
        // }
    }

    void Take( GameObject taker ) {
        objectToPickup.transform.parent = taker.transform;
        isHeld = true;
        objectToPickup.transform.localPosition = Vector3.zero;
        if ( collider != null ) {
            collider.enabled = false; 
        }
    }

    void Drop() {
        objectToPickup.transform.parent = null;
        isHeld = false;
        if ( collider != null ) {
            collider.enabled = true; 
        }
    }
}
