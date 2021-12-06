using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampfireRegen : MonoBehaviour
{

    public GameEvent campfire;

    public void OnCollisionStay2D(Collision2D obj) {
        campfire.Raise();
    }
}
