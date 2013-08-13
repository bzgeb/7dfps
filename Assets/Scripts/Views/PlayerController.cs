using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public Camera cam;
    public float raycastDistance;
    public LayerMask clickLayerMask;
    public string clickableTag;
    public Player playerModel;

    bool holdingObj;
    Pickup objHeld;

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
            if ( holdingObj ) {
                objHeld.SendMessage("Drop"); 
                holdingObj = false;
                objHeld = null;
            } else {
                Ray inputRay = new Ray( camTransform.position, camTransform.forward );
                RaycastHit hit;

                if ( Physics.Raycast ( inputRay, out hit, raycastDistance, clickLayerMask ) ) {
                    if ( hit.collider.CompareTag( clickableTag ) ) {
                        hit.collider.SendMessage( "OnClick", gameObject );
                    }
                }
            }
        }	
	}

    void Pickup( Pickup obj ) {
        objHeld = obj;
        holdingObj = true;
    }
}
