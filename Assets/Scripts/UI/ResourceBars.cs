using UnityEngine;
using UnityEngine.UI;

public abstract class ResourceBars : MonoBehaviour
{
    public Slider slider;
    public EntityData Entity;
    public abstract void UpdateUI();
}
