using System;
using UnityEngine;

[CreateAssetMenu]
public class BossVariables : ScriptableObject
{
    public float speed;
    public float maxStamina = 0;
    public float maxHP = 0;
    public float staminaPerSecond;
    public float knockbackScale = 1f;
    

    public static implicit operator float(BossVariables variable)
    {
        return variable.maxHP;
    }
}

//from Unite Austin 2017 https://www.youtube.com/watch?v=raQ3iHhE_Kk around 19 minutes
// and https://gamedevbeginner.com/how-to-get-a-variable-from-another-script-in-unity-the-right-way/ on ScriptableObjects