/*using System;

[Serializable]
public class FloatReference
{
    public bool UseConstant = true;
    public float ConstantValue;
    public FloatVariable variable;

    // the => is a lambda operator
    // the x ? y : z is a conditional operator expression i.e. if UseConstant == true then ConstantValue, else if UseConstant == false then variable.Value
    public FloatReference(float value)
    {
        UseConstant = true;
        ConstantValue = value;
    }
    public float Value => UseConstant ? ConstantValue : variable.value;

    //this lets you use FloatReference as a float without casting it into float first
    public static implicit operator float(FloatReference reference)
    {
        return reference.Value;
    }
}
//provides a way to use constants instead of the variables when needed
//from Unite Austin 2017 https://www.youtube.com/watch?v=raQ3iHhE_Kk
*/