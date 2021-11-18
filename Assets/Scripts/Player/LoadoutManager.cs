using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadoutManager : MonoBehaviour
{

    public List<Dodge> DodgeList;
    public List<MeleeAttack> MeleeList;
    public List<RangedAttack> RangedList;
    public List<Special> SpecialList;
    public List<Parry> ParryList;

    public int checkList()
    {
        foreach (var dodge in DodgeList)
        {            
            Debug.Log(dodge.ToString());
            if (dodge is Dodge_Dash)
            {
                return DodgeList.IndexOf(dodge);
            }
        }
        return 0;
    }

}
