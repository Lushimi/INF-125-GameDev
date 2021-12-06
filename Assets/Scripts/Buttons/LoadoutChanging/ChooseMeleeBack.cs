using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseMeleeBack : ChooseButton
{
    public override void Start()
    {
        buttonID = lm.MeleeToID(pc.meleeAttack);
        img.color = colors[buttonID];
    }
    public override void ChangeButton()
    {

        buttonID = lm.MeleeToID(GameObject.Find("Player").GetComponent<PlayerControl>().meleeAttack);
        if (buttonID == 0)
        {
            buttonID = lm.MeleeList.Count - 1;
        }
        else
        {
            buttonID = buttonID - 1;
        }

        while (pc.dodgeUnlocked[buttonID] != 1)
        {
            //Debug.Log(dodgeId);
            if (buttonID == 0)
            {
                buttonID = lm.MeleeList.Count - 1;
            }
            else
            {
                buttonID = buttonID - 1;
            }
        }
        img.color = colors[buttonID];
        pc.meleeAttack = lm.idToMelee(buttonID);

    }
}
