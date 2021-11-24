using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseDodge : MonoBehaviour
{
    public int dodgeId;
    public LoadoutManager lm => GameObject.Find("LoadoutManager").GetComponent<LoadoutManager>();
    public PlayerControl pc => GameObject.Find("Player").GetComponent<PlayerControl>();
    public Image img;
    public List<Color> colors = new List<Color>() { Color.blue, Color.green, Color.red, Color.black, Color.white, Color.yellow};
    void Start()
    {
        dodgeId = lm.DodgeToID(pc.dodgeMove);
        img.color = colors[dodgeId];
    }
    public void ChangeDodge()
    {
        dodgeId = lm.DodgeToID(GameObject.Find("Player").GetComponent<PlayerControl>().dodgeMove);
        dodgeId = (dodgeId + 1) % lm.DodgeList.Count;
        
        while (pc.dodgeUnlocked[dodgeId] != 1)
        {
            dodgeId = (dodgeId + 1) % lm.DodgeList.Count;
            //Debug.Log(dodgeId);
        }
        
        img.color = colors[dodgeId];
        pc.dodgeMove = lm.idToDodge(dodgeId);
        
    }
}
