using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseParryBack : ChooseButton
{
    public override void Start()
    {
        buttonID = lm.ParryToID(pc.parryMove);
        img.color = colors[buttonID];
    }
    public override void ChangeButton()
    {

        buttonID = lm.ParryToID(GameObject.Find("Player").GetComponent<PlayerControl>().parryMove);
        if (buttonID == 0)
        {
            buttonID = lm.ParryList.Count - 1;
        }
        else
        {
            buttonID = buttonID - 1;
        }

        while (pc.parryUnlocked[buttonID] != 1)
        {
            if (buttonID == 0)
            {
                buttonID = lm.ParryList.Count - 1;
            }
            else
            {
                buttonID = buttonID - 1;
            }
            //Debug.Log(parryId);
        }
        img.color = colors[buttonID];
        pc.parryMove = lm.idToParry(buttonID);

    }
}