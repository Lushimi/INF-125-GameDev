using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider staminaBar;
    public PlayerControl PlayerObject;
    [SerializeField]
    private FloatVariable maxStamina;


    // Start is called before the first frame update
    void Awake()
    {
        staminaBar.maxValue = maxStamina;
        staminaBar.value = PlayerObject.Player.currentStamina;
        
    }

    public void UpdateUI() 
    {
        staminaBar.value = PlayerObject.Player.currentStamina;
    }
}
