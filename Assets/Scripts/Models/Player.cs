using UnityEngine;
using System.Collections;

public enum PlayerIndex {
    One,
    Two
};

public class Player : MonoBehaviour {
    public PlayerIndex index;
    public Animator animator;

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

    string nextWeaponButton;
    public string NextWeaponButton {
        get {
            return nextWeaponButton;
        }
        private set {
            nextWeaponButton = value;
        }
    }

    string runButton;
    public string RunButton {
        get {
            return runButton;
        } 
        private set {
            runButton = value;
        }
    }

    string crouchButton;
    public string CrouchButton {
        get {
            return crouchButton;
        } 
        private set {
            crouchButton = value;
        }
    }

    string reloadButton;
    public string ReloadButton {
        get {
            return reloadButton;
        } 
        private set {
            reloadButton = value;
        }
    }

    public OuyaPlayer ouyaPlayer { get; set; }

    bool usingController = true;

    // do we want to scan for trigger and d-pad button events ?
    public bool continuousScan = true;
    
    // the type of deadzone we want to use for convenience access
    public DeadzoneType deadzoneType = DeadzoneType.CircularMap;

    // the size of the deadzone
    public float deadzone = 0.25f;
    public float triggerThreshold = 0.1f;

    public bool GameOver { get; set; }

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
        NextWeaponButton = string.Format("{0} NextWeapon", prefix);
        RunButton = string.Format("{0} Run", prefix);
        CrouchButton = string.Format("{0} Crouch", prefix);
        ReloadButton = string.Format("{0} Reload", prefix);

        animator.SetFloat("Speed", 0);

        OuyaInput.SetSinglePlayerSecure( false );

        // set button state scanning to receive input state events for trigger and d-pads
        OuyaInput.SetContinuousScanning(continuousScan);
        
        // define the deadzone if you want to use advanced joystick and trigger access
        OuyaInput.SetDeadzone(deadzoneType, deadzone);
        OuyaInput.SetTriggerThreshold(triggerThreshold);

        // do one controller update here to get everything started as soon as possible
        OuyaInput.UpdateControllers();

        vp_FPInput input = GetComponent<vp_FPInput>();
        if ( input != null ) {
            input.Player.SetWeapon.TryStart(1);
        }
    }

    void OnEnable() {
        EventManager.Register( "OnHunterWins", OnHunterWins );
        EventManager.Register( "OnGathererWins", OnGathererWins );
    }

    void OnDisable() {
        EventManager.Deregister( "OnHunterWins", OnHunterWins );
        EventManager.Deregister( "OnGathererWins", OnGathererWins );
    }

    void OnHunterWins( params object[] args ) {
        OnGameOver();
    }

    void OnGathererWins( params object[] args ) {
        OnGameOver();
    }

    void OnGameOver() {
        Debug.Log("Game Over");
        GameOver = true;
    }

    void Update() {
        if ( usingController ) {
            OuyaInput.UpdateControllers();
            usingController = !CheckIfUsingKeyboard();
        } else {
            usingController = CheckIfUsingController();
        }

        if ( !GameOver ) {
            animator.SetFloat( "Speed", Mathf.Abs( GetVerticalAxis() ) );
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
        if ( index == PlayerIndex.Two ) {
            return result;
        }

        if ( usingController ) {
            result = OuyaInput.GetButtonDown( OuyaButton.U, ouyaPlayer );
        } else {
            result = Input.GetButtonDown( PickupButton );         
        }

        return result;
    }

    public bool GetNextWeaponButton() {
        bool result = false;
        if ( usingController ) {
            result = OuyaInput.GetButton( OuyaButton.Y, ouyaPlayer );
        } else {
            result = Input.GetButton( NextWeaponButton );
        }

        return result;
    }

    public bool GetRunButton() {
        bool result = false;
        if ( usingController ) {
            result = OuyaInput.GetButton( OuyaButton.A, ouyaPlayer );
        } else {
            result = Input.GetButton( RunButton );
        }

        return result;
    }

    public bool GetFireButton() {
        bool result = false;
        if ( usingController ) {
            // result = (OuyaInput.GetAxis( OuyaAxis.RT, ouyaPlayer ) != 0) ? true : false;
            result = OuyaInput.GetButton( OuyaButton.O, ouyaPlayer );
        } else {
            result = Input.GetButton( FireButton );
        }

        return result;
    }

    public bool GetCrouchButton() {
        bool result = false; 
        // if ( usingController ) {
        //     result = OuyaInput.GetButton( OuyaButton.O, ouyaPlayer );
        // } else {
        //     result = Input.GetButton( CrouchButton );
        // }

        return result;
    }

    public bool GetReloadButton() {
        bool result = false; 
        if ( index == PlayerIndex.One ) {
            return result;
        }

        if ( usingController ) {
            result = OuyaInput.GetButtonDown( OuyaButton.U, ouyaPlayer );
        } else {
            result = Input.GetButton( ReloadButton );
        }

        return result;
    }
}
