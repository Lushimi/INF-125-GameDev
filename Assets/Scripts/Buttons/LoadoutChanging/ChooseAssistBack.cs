using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseAssistBack : ChooseButton
{
    public override void Start()
    {
        buttonID = lm.AssistToID(pc.assistMove);
        img.color = colors[buttonID];
    }
    public override void ChangeButton()
    {

        buttonID = lm.AssistToID(GameObject.Find("Player").GetComponent<PlayerControl>().assistMove);

        if (buttonID == 0)
        {
            buttonID = lm.AssistList.Count-1;
        }
        else
        {
            buttonID = buttonID - 1;
        }

        while (pc.assistUnlocked[buttonID] != 1)
        {
            if (buttonID == 0)
            {
                buttonID = lm.AssistList.Count - 1;
            }
            else
            {
                buttonID = buttonID - 1;
            }
            //Debug.Log(assistId);
        }
        img.color = colors[buttonID];
        pc.assistMove = lm.idToAssist(buttonID);

    }
}
