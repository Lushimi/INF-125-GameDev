using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CameraController), true)]
//allows this class to edit multiple objects simultaneously
[CanEditMultipleObjects]
public class CameraControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {

        DrawDefaultInspector();

        //creates "resourceBar" which is a cast of the target variable
        CameraController cameraControl = (CameraController)target;
        if (GUILayout.Button("SpawnPlayer"))
        {
            cameraControl.SpawnPlayer();
        }

    }
}

//following this unity tutorial
//https://www.youtube.com/watch?v=_fNgn3Arpoo
//and to make it support inheritance https://answers.unity.com/questions/51615/do-custom-inspectors-support-inheritance.html