using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public Camera cam;
    public float raycastDistance;
    public LayerMask clickLayerMask;
    public string clickableTag;
    public Player playerModel;
    public GameObject pickupParent;

    bool hoveringLastFrame;

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
        hoveringLastFrame = false;
    }

    void Start() {
        camTransform = cam.transform;
    }

    void OnEnable() {
        EventManager.Register( "OnKilled", OnKilled );
    }

    void OnDisable() {
        EventManager.Deregister( "OnKilled", OnKilled );
    }
	
	// Update is called once per frame
	void Update () {
        Ray inputRay = new Ray( camTransform.position, camTransform.forward );
        RaycastHit hit;
        bool hovering = false;

        if ( Physics.Raycast(inputRay, out hit, raycastDistance, clickLayerMask ) ) {
            hovering = true;
            hoveringLastFrame = true;
            EventManager.Push( "OnHoverOverObject" );
        } else if ( hoveringLastFrame ) {
            hoveringLastFrame = false;
            EventManager.Push( "OnHoverOffObject" );
        }

        if ( playerModel.GetPickupButton() ) {
            if ( hovering ) {
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

    void OnKilled( params object[] args ) {
        if ( holdingObj ) {
            Drop();
        }
    }
}
