using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseRangedBack : ChooseButton
{
    public override void Start()
    {
        buttonID = lm.RangedToID(pc.rangedAttack);
        img.color = colors[buttonID];
    }
    public override void ChangeButton()
    {

        buttonID = lm.RangedToID(GameObject.Find("Player").GetComponent<PlayerControl>().rangedAttack);
        if (buttonID == 0)
        {
            buttonID = lm.RangedList.Count - 1;
        }
        else
        {
            buttonID = buttonID - 1;
        }

        while (pc.dodgeUnlocked[buttonID] != 1)
        {
            if (buttonID == 0)
            {
                buttonID = lm.RangedList.Count - 1;
            }
            else
            {
                buttonID = buttonID - 1;
            }
        }
        img.color = colors[buttonID];
        pc.rangedAttack = lm.idToRanged(buttonID);

    }
}