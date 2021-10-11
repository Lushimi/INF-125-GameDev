using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int damage;
    public float startup;
    public float endlag;
    public float range;
    public Transform attackPoint;
    public LayerMask enemyLayers;


    public virtual void attack()
    {
        return;
    }
}
