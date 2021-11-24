using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseRanged : ChooseButton
{
    public override void Start()
    {
        buttonID = lm.RangedToID(pc.rangedAttack);
    }
    public override void ChangeButton()
    {

        buttonID = lm.RangedToID(GameObject.Find("Player").GetComponent<PlayerControl>().rangedAttack);
        buttonID = (buttonID + 1) % lm.RangedList.Count;

        while (pc.dodgeUnlocked[buttonID] != 1)
        {
            buttonID = (buttonID + 1) % lm.RangedList.Count;
            //Debug.Log(dodgeId);
        }
        img.color = colors[buttonID];
        pc.rangedAttack = lm.idToRanged(buttonID);

    }
}
