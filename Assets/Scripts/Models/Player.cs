using UnityEngine;
using System.Collections;

public enum PlayerIndex {
    One,
    Two
};

public class Player : MonoBehaviour {
    public PlayerIndex index;

    string horizontalAxis;
    public string HorizontalAxis {
        get {
            return horizontalAxis;
        }
        private set {
            horizontalAxis = value;
        }
    }

    string verticalAxis;
    public string VerticalAxis {
        get {
            return verticalAxis;
        }
        private set {
            verticalAxis = value;
        }
    }

    string fireButton;
    public string FireButton {
        get {
            return fireButton;
        }
        private set {
            fireButton = value;
        }
    }

    string jumpButton;
    public string JumpButton {
        get {
            return jumpButton;
        }
        private set {
            jumpButton = value;
        }
    }

    string pickupButton;
    public string PickupButton {
        get {
            return pickupButton;
        }
        private set {
            pickupButton = value;
        }
    }

    public OuyaPlayer ouyaPlayer { get; set; }

    bool usingController = true;

    void Start() {
        string prefix = "";
        if ( index == PlayerIndex.One ) {
            ouyaPlayer = OuyaPlayer.P01;
            prefix = "P1";
        } else if ( index == PlayerIndex.Two ) {
            ouyaPlayer = OuyaPlayer.P02;
            prefix = "P2";
        }

        HorizontalAxis = string.Format("{0} Horizontal", prefix);
        VerticalAxis = string.Format("{0} Vertical", prefix);
        FireButton = string.Format("{0} Fire1", prefix);
        JumpButton = string.Format("{0} Jump", prefix);
        PickupButton = string.Format("{0} Pickup", prefix);
    }

    void Update() {
        if ( usingController ) {
            OuyaInput.UpdateControllers();
            usingController = !CheckIfUsingKeyboard();
        } else {
            usingController = CheckIfUsingController();
        }
    }

    bool CheckIfUsingController() {
        OuyaInput.UpdateControllers();
        Vector2 horizontalMovement = OuyaInput.GetJoystick( OuyaJoystick.LeftStick, ouyaPlayer );
        if ( horizontalMovement.x != 0 || horizontalMovement.y != 0 ) {
            return true;
        }

        return false;
    }

    bool CheckIfUsingKeyboard() {
        if ( Input.GetAxisRaw(HorizontalAxis) != 0 || Input.GetAxisRaw(VerticalAxis) != 0 ) {
            return true; 
        } 

        return false;
    }

    public float GetHorizontalAxis() {
        float result = 0;
        if ( usingController ) {
            result = OuyaInput.GetJoystick( OuyaJoystick.LeftStick, ouyaPlayer ).x;
        } else {
            result = Input.GetAxisRaw( HorizontalAxis );
        }

        return result;
    }

    public float GetVerticalAxis() {
        float result = 0;
        if ( usingController ) {
            result = OuyaInput.GetJoystick( OuyaJoystick.LeftStick, ouyaPlayer ).y;
        } else {
            result = Input.GetAxisRaw( VerticalAxis );         
        }

        return result;
    }


    public float GetHorizontalAxis2() {
        float result = 0;
        if ( usingController ) {
            result = OuyaInput.GetJoystick( OuyaJoystick.RightStick, ouyaPlayer ).x;
        } else {
            result = Input.GetAxisRaw( "Mouse X" );
        }

        return result;
    }

    public float GetVerticalAxis2() {
        float result = 0;
        if ( usingController ) {
            result = OuyaInput.GetJoystick( OuyaJoystick.RightStick, ouyaPlayer ).y;
        } else {
            result = Input.GetAxisRaw( "Mouse Y" );         
        }

        return result;
    }

    public bool GetPickupButton() {
        bool result = false;
        if ( usingController ) {
            result = OuyaInput.GetButton( OuyaButton.U, ouyaPlayer );
        } else {
            result = Input.GetButton( PickupButton );         
        }

        return result;
    }
}
