using System;
using UnityEngine;

[CreateAssetMenu]
public class FloatVariable : ScriptableObject
{
    public float value;

    //this lets you use FloatVariable as a float without casting it into float first
    public static implicit operator float(FloatVariable variable)
    {
        return variable.value;
    }

}

//from Unite Austin 2017 https://www.youtube.com/watch?v=raQ3iHhE_Kk around 19 minutes
// and https://gamedevbeginner.com/how-to-get-a-variable-from-another-script-in-unity-the-right-way/ on ScriptableObjects