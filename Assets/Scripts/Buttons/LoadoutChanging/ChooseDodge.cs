using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseDodge : ChooseButton
{
    public override void Start()
    {
        buttonID = lm.DodgeToID(pc.dodgeMove);
    }
    public override void ChangeButton()
    {

        buttonID = lm.DodgeToID(GameObject.Find("Player").GetComponent<PlayerControl>().dodgeMove);
        buttonID = (buttonID + 1) % lm.DodgeList.Count;
        
        while (pc.dodgeUnlocked[buttonID] != 1)
        {
            buttonID = (buttonID + 1) % lm.DodgeList.Count;
            //Debug.Log(dodgeId);
        }
        img.color = colors[buttonID];
        pc.dodgeMove = lm.idToDodge(buttonID);
        
    }
}
