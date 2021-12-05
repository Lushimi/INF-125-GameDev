using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseSpecial : ChooseButton
{
    public override void Start()
    {
        buttonID = lm.SpecialToID(pc.specialAttack);
        img.color = colors[buttonID];
    }
    public override void ChangeButton()
    {

        buttonID = lm.SpecialToID(GameObject.Find("Player").GetComponent<PlayerControl>().specialAttack);
        buttonID = (buttonID + 1) % lm.SpecialList.Count;

        while (pc.specialUnlocked[buttonID] != 1)
        {
            buttonID = (buttonID + 1) % lm.SpecialList.Count;
            //Debug.Log(specialId);
        }
        img.color = colors[buttonID];
        pc.specialAttack = lm.idToSpecial(buttonID);

    }
}
