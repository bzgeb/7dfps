using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {
    public GameObject objectToPickup;
    void OnClick( GameObject clicker ) {
        objectToPickup.transform.parent = clicker.transform;
    }
}
