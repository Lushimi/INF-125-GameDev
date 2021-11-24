using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ChooseButton : MonoBehaviour
{

    public int buttonID;
    public LoadoutManager lm => GameObject.Find("LoadoutManager").GetComponent<LoadoutManager>();
    public PlayerControl pc => GameObject.Find("Player").GetComponent<PlayerControl>();
    public Image img;
    public List<Color> colors = new List<Color>() { Color.blue, Color.green, Color.red, Color.black, Color.white, Color.yellow };
    public virtual void Start()
    {
        img.color = colors[buttonID];
    }
    public virtual void ChangeButton()
    {
    }


}
