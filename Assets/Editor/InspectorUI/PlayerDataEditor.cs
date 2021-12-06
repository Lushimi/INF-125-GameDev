using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerData), true)]
//allows this class to edit multiple objects simultaneously
[CanEditMultipleObjects]
public class PlayerDataEditor : Editor
{
    public override void OnInspectorGUI()
    {

        DrawDefaultInspector();

        //creates "resourceBar" which is a cast of the target variable
        PlayerData playerData= (PlayerData)target;
        if (GUILayout.Button("KillPlayer"))
        {
            playerData.Die();
        }

    }
}
