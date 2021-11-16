using UnityEngine;
using UnityEngine.UI;

public abstract class ResourceBars : MonoBehaviour
{
    public Slider slider;
    public EntityData Entity;
    public abstract void UpdateUI();

    public void FindPlayer()
    {
        Entity = GameObject.Find("Player").GetComponent<PlayerData>();
    }
}
