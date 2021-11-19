using UnityEngine;
using UnityEditor;

//this adds a custom inspector button to call the UpdateUI function on resource bars
//the second parameter allows this to apply to all inherited classes
[CustomEditor(typeof(GameEvent), true)]
//allows this class to edit multiple objects simultaneously
[CanEditMultipleObjects]
public class GameEventEditor : Editor
{
    public override void OnInspectorGUI()
    {

        DrawDefaultInspector();

        //creates "resourceBar" which is a cast of the target variable
        GameEvent gameEvent = (GameEvent)target;
        if (GUILayout.Button("Raise"))
        {
            gameEvent.Raise();
        }

    }
}
