using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

namespace UnityAssets {
    public enum AxisType {
        KeyOrMouseButton = 0,
        MouseMovement = 1,
        JoystickAxis = 2
    };
    public class AddInputAxes : ScriptableWizard {
        SerializedObject inputManager;

        [MenuItem( "Assets/Add Input Axes" )]
        static void CreateWizard() {
            ScriptableWizard.DisplayWizard<AddInputAxes>( "Add Axes", "Do it" );
        }


        void OnWizardCreate() {
            inputManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/InputManager.asset")[0]);
            SerializedProperty axes = inputManager.FindProperty( "m_Axes" );
            int axesLength = axes.arraySize;
            int c = 0;
            for ( int i = 3; i < 12; ++i ) {
                for ( int j = 1; j < 11; ++j ) {
                    axes.InsertArrayElementAtIndex( axesLength + c );
                    SerializedProperty axis = axes.GetArrayElementAtIndex( axesLength + c );
                    GetChildProperty( axis, "m_Name" ).stringValue = string.Format("Joy{0} Axis {1}", i, j);
                    GetChildProperty( axis, "gravity" ).floatValue = 0;
                    GetChildProperty( axis, "dead" ).floatValue = 0.19f;
                    GetChildProperty( axis, "sensitivity" ).floatValue = 1;
                    GetChildProperty( axis, "type" ).intValue = (int)AxisType.JoystickAxis;
                    GetChildProperty( axis, "axis" ).intValue = j - 1;
                    GetChildProperty( axis, "joyNum" ).intValue = i;
                    ++c;
                }
            }

            inputManager.ApplyModifiedProperties();
        }


        public static SerializedProperty GetChildProperty (SerializedProperty parent, string name) {
            SerializedProperty child = parent.Copy ();
            child.Next (true);

            do
            {
                if (child.name == name)
                {
                    return child;
                }
            }
            while (child.Next (false));

            return null;
        }
    }
}
