using UnityEngine;
using UnityEngine.Events; // uses UnityEvents

//only functions when used with GameEvent
//this derives from monobehavior, we attach this to the object that needs to listen for an event.

public class GameEventListener : MonoBehaviour
{
    [SerializeField]
    private GameEvent gameEvent; // GameEvent being subscribed to
    [SerializeField]
    private UnityEvent response; // UnityEvent response when GameEvent raises the event

    private void OnEnable() // when this gameobject is enabled, register this to the GameEvent 
    {
        gameEvent.RegisterListener(this);
    }

    private void OnDisable() //  when this gameobject is disabled, unregister this from the GameEvent list
    {
        gameEvent.UnregisterListener(this);
    }

    public void OnEventRaised() // invokes the unity event when the GameEvent has been raised
    {
        response.Invoke();
    }
}

//created following this tutorial
//https://www.raywenderlich.com/2826197-scriptableobject-tutorial-getting-started