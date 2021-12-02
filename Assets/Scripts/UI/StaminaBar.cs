using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : ResourceBars
{
    // Start is called before the first frame update
    public override void Start()
    {

        if (Entity.maxStamina == null)
            slider.maxValue = Entity.bossVariables.maxStamina;
        else
            slider.maxValue = Entity.maxStamina;
        slider.value = Entity.currentStamina;

    }

    public override void UpdateUI() 
    {
        slider.value = Entity.currentStamina;
    }

}
