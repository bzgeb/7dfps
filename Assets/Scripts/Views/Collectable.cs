using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SphereCollider))]
public class Collectable : MonoBehaviour {
    void Awake() {
        SphereCollider collider = GetComponent<SphereCollider>();
        collider.isTrigger = true;
    }

    void OnTriggerEnter( Collider other ) {
        other.SendMessage( "On" + gameObject.name + "Enter", this );
    }

    void OnClick() {
        Debug.Log("Clicked");
    }
}
