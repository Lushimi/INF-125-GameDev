using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseDodgeBack : ChooseButton
{
    public override void Start()
    {
        buttonID = lm.DodgeToID(pc.dodgeMove);
        img.color = colors[buttonID];
    }
    public override void ChangeButton()
    {

        buttonID = lm.DodgeToID(GameObject.Find("Player").GetComponent<PlayerControl>().dodgeMove);
        if (buttonID == 0)
        {
            buttonID = lm.DodgeList.Count - 1;
        }
        else
        {
            buttonID = buttonID - 1;
        }

        while (pc.dodgeUnlocked[buttonID] != 1)
        {
            if (buttonID == 0)
            {
                buttonID = lm.DodgeList.Count - 1;
            }
            else
            {
                buttonID = buttonID - 1;
            }
            //Debug.Log(dodgeId);
        }
        img.color = colors[buttonID];
        pc.dodgeMove = lm.idToDodge(buttonID);

    }
}
