using UnityEngine;
using UnityEngine.UI;

public abstract class ResourceBars : MonoBehaviour
{
    public Slider slider;

    public abstract void UpdateUI();
}
