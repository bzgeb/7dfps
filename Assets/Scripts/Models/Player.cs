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

    void Start() {
        string prefix = "";
        if ( index == PlayerIndex.One ) {
            prefix = "P1";
        } else if ( index == PlayerIndex.Two ) {
            prefix = "P2";
        }

        HorizontalAxis = string.Format("{0} Horizontal", prefix);
        VerticalAxis = string.Format("{0} Vertical", prefix);
        FireButton = string.Format("{0} Fire1", prefix);
        JumpButton = string.Format("{0} Jump", prefix);
    }
}
