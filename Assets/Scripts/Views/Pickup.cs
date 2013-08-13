using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {
    public GameObject objectToPickup;
    public bool isHeld;

    void Awake() {
        gameObject.tag = "Clickable";
        isHeld = false;
    }

    void OnClick( GameObject clicker ) {
        Take( clicker );
    }

    void Update() {
        if ( isHeld ) {
            if ( Input.GetMouseButton(1) ) {
                Drop();
            }
        }
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
