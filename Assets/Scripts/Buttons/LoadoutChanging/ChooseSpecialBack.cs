using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseSpecialBack : ChooseButton
{
    public override void Start()
    {
        buttonID = lm.SpecialToID(pc.specialAttack);
        img.color = colors[buttonID];
    }
    public override void ChangeButton()
    {

        buttonID = lm.SpecialToID(GameObject.Find("Player").GetComponent<PlayerControl>().specialAttack);
        if (buttonID == 0)
        {
            buttonID = lm.SpecialList.Count - 1;
        }
        else
        {
            buttonID = buttonID - 1;
        }

        while (pc.specialUnlocked[buttonID] != 1)
        {
            if (buttonID == 0)
            {
                buttonID = lm.SpecialList.Count - 1;
            }
            else
            {
                buttonID = buttonID - 1;
            }
            //Debug.Log(specialId);
        }
        img.color = colors[buttonID];
        pc.specialAttack = lm.idToSpecial(buttonID);

    }
}

