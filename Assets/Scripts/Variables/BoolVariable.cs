using UnityEngine;

[CreateAssetMenu]
public class BoolVariable : ScriptableObject
{
    public bool value;

    //this lets you use FloatVariable as a float without casting it into float first
    public static implicit operator bool(BoolVariable variable)
    {
        return variable.value;
    }

}
