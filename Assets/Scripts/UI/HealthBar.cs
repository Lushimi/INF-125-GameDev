using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : ResourceBars
{
    // Start is called before the first frame update
    public override void Start()
    {
        if (Entity.maxHP == null)
            slider.maxValue = Entity.bossVariables;
        else
            slider.maxValue = Entity.maxHP;
        slider.value = Entity.currentHealth;
    }

    public override void UpdateUI() 
    {
        slider.value = Entity.currentHealth;
    }
}
