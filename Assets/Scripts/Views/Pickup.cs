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

    void OnClick( GameObject clicker ) {
        Take( clicker );
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
    }

    void Drop() {
        objectToPickup.transform.parent = null;
        isHeld = false;
    }
}
