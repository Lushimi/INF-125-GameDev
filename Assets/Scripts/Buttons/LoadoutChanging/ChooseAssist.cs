using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseAssist : ChooseButton
{
    public override void Start()
    {
        buttonID = lm.AssistToID(pc.assistMove);
        img.color = colors[buttonID];
    }
    public override void ChangeButton()
    {

        buttonID = lm.AssistToID(GameObject.Find("Player").GetComponent<PlayerControl>().assistMove);
        buttonID = (buttonID + 1) % lm.AssistList.Count;

        while (pc.assistUnlocked[buttonID] != 1)
        {
            buttonID = (buttonID + 1) % lm.AssistList.Count;
            //Debug.Log(assistId);
        }
        img.color = colors[buttonID];
        pc.assistMove = lm.idToAssist(buttonID);

    }
}
