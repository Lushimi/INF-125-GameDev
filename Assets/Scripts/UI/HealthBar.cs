using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : ResourceBars
{
    public EntityData Entity;

    // Start is called before the first frame update
    void Start()
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
