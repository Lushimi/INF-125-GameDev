using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : ResourceBars
{
    public bool NegativeStaminaBool = false;
    // Start is called before the first frame update
    public override void Start()
    {

        if (Entity.maxStamina == null)
            slider.maxValue = Entity.bossVariables.maxStamina;
        else
            slider.maxValue = Entity.maxStamina;
        slider.value = Entity.currentStamina;

    }

    public void Update()
    {
        if (NegativeStaminaBool == false)
        {
            slider.gameObject.transform.Find("Background").GetComponent<Image>().color = new Color (255,255,255);
        }
        else if (NegativeStaminaBool == true)
        {
            slider.gameObject.transform.Find("Background").GetComponent<Image>().color = new Color(255, 255, 255, 0.5f);
            //slider.fillRect = slider.gameObject.transform.Find("Fill Area").Find("Negative Stamina Fill").GetComponent<RectTransform>();

        }
    }

    public override void UpdateUI() 
    {
        slider.value = Entity.currentStamina;
    }

    public void toggleNegativeStamina()
    {
        NegativeStaminaBool = NegativeStaminaBool? false: true;

    }

}
