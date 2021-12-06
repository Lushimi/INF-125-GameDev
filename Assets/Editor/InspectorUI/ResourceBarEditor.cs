using UnityEngine;
using UnityEditor;

//this adds a custom inspector button to call the UpdateUI function on resource bars
//the second parameter allows this to apply to all inherited classes
[CustomEditor(typeof(ResourceBars), true)]
//allows this class to edit multiple objects simultaneously
[CanEditMultipleObjects]
public class ResourceBarEditor : Editor
{
    public override void OnInspectorGUI()
    {

        DrawDefaultInspector();

        //creates "resourceBar" which is a cast of the target variable
        ResourceBars resourceBar = (ResourceBars)target;
        if (GUILayout.Button("Update UI"))
        {
            resourceBar.UpdateUI();
        }

    }
}

//following this unity tutorial
//https://www.youtube.com/watch?v=_fNgn3Arpoo
//and to make it support inheritance https://answers.unity.com/questions/51615/do-custom-inspectors-support-inheritance.html