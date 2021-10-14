using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : ResourceBars
{
    public PlayerData Player;
    [SerializeField]
    private FloatVariable maxHP;


    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = maxHP;
        slider.value = Player.currentHealth;
    }

    public override void UpdateUI() 
    {
        slider.value = Player.currentHealth;
    }
}
