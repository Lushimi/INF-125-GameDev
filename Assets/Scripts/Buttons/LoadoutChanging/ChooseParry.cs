using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseParry : ChooseButton
{
    public override void Start()
    {
        buttonID = lm.ParryToID(pc.parryMove);
    }
    public override void ChangeButton()
    {

        buttonID = lm.ParryToID(GameObject.Find("Player").GetComponent<PlayerControl>().parryMove);
        buttonID = (buttonID + 1) % lm.ParryList.Count;

        while (pc.parryUnlocked[buttonID] != 1)
        {
            buttonID = (buttonID + 1) % lm.ParryList.Count;
            //Debug.Log(parryId);
        }
        img.color = colors[buttonID];
        pc.parryMove = lm.idToParry(buttonID);

    }
}
