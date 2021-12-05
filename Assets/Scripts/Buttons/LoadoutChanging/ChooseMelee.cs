using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseMelee : ChooseButton
{
    public override void Start()
    {
        buttonID = lm.MeleeToID(pc.meleeAttack);
        img.color = colors[buttonID];
    }
    public override void ChangeButton()
    {

        buttonID = lm.MeleeToID(GameObject.Find("Player").GetComponent<PlayerControl>().meleeAttack);
        buttonID = (buttonID + 1) % lm.MeleeList.Count;

        while (pc.dodgeUnlocked[buttonID] != 1)
        {
            buttonID = (buttonID + 1) % lm.MeleeList.Count;
            //Debug.Log(dodgeId);
        }
        img.color = colors[buttonID];
        pc.meleeAttack = lm.idToMelee(buttonID);

    }
}
