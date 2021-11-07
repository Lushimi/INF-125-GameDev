using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadoutManager : MonoBehaviour
{

    public List<Dodge> DodgeList;
    public List<MeleeAttack> MeleeList;
    public List<RangedAttack> RangedList;
    public List<SpecialFireball> SpecialList;
    public List<Parry> ParryList;

    public void checkList()
    {
        Dodge[] dodges = gameObject.GetComponents<Dodge>();
        foreach (var dodge in dodges)
        {            
            Debug.Log(dodge.ToString());
            if (dodge is Dodge_Roll)
            {
                DodgeList.Add(dodge);
            }
        }
    }

}
