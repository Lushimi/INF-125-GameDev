using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : ResourceBars
{
    public PlayerData Player;
    [SerializeField]
    private FloatVariable maxStamina;


    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = maxStamina;
        slider.value = Player.currentStamina;
        
    }

    public override void UpdateUI() 
    {
        slider.value = Player.currentStamina;
    }
}