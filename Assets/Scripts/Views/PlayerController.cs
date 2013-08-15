using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public Camera cam;
    public float raycastDistance;
    public LayerMask clickLayerMask;
    public string clickableTag;
    public Player playerModel;
    public GameObject pickupParent;

    bool holdingObj;
    public bool HoldingObj {
        get { return holdingObj; } 
    }

    Pickup objHeld;
    public Pickup ObjHeld {
        get { return objHeld; } 
    }

    Transform camTransform;

    void Awake() {
        holdingObj = false;
    }

    void Start() {
        camTransform = cam.transform;
    }
	
	// Update is called once per frame
	void Update () {
        if ( playerModel.GetPickupButton() ) {
            Ray inputRay = new Ray( camTransform.position, camTransform.forward );
            RaycastHit hit;

            if ( Physics.Raycast ( inputRay, out hit, raycastDistance, clickLayerMask ) ) {
                if ( hit.collider.CompareTag( clickableTag ) ) {
                    hit.collider.SendMessage( "OnClick", new object[] { gameObject, pickupParent } );
                }
            } else {
                if ( holdingObj ) {
                    Drop();
                }
            }
        }	
	}

    void Pickup( Pickup obj ) {
        objHeld = obj;
        holdingObj = true;
    }

    void Drop() {
        objHeld.SendMessage("Drop"); 
        holdingObj = false;
        objHeld = null;
    }
}
