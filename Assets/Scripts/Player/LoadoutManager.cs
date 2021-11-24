using System;
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
    //public List<Assist> AssistList;

    public List<IList> allLists => new List<IList>() { DodgeList,RangedList, SpecialList, ParryList };
    public Dodge idToDodge(int id)
    {
        Dodge returnVal = null;
        DodgeList.ForEach(
            dodge => {
                if (DodgeList.IndexOf(dodge) == id)
                { returnVal = dodge; }
            }
            );
        return returnVal;
    }

    public int DodgeToID(Dodge curDodge)
    {
        int returnVal = -1;
        DodgeList.ForEach(
            dodge => {
                if (dodge.GetType().ToString() == curDodge.GetType().ToString())
                { returnVal = DodgeList.IndexOf(dodge); }
            }
            );
        return returnVal;
    }

    public Dodge idToDodge(string id)
    {
        Dodge returnVal = null;
        DodgeList.ForEach(
            dodge => {
                if (dodge.GetType().ToString() == id)
                { returnVal = dodge; }
            }
            );
        return returnVal;
    }

    public MeleeAttack idToMelee(int id)
    {
        MeleeAttack returnVal = null;
        MeleeList.ForEach(
            dodge => {
                if (MeleeList.IndexOf(dodge) == id)
                { returnVal = dodge; }
            }
            );
        return returnVal;
    }

    public MeleeAttack idToMelee(string id)
    {
        MeleeAttack returnVal = null;
        MeleeList.ForEach(
            dodge => {
                if (dodge.GetType().ToString() == id)
                { returnVal = dodge; }
            }
            );
        return returnVal;
    }

    public RangedAttack idToRanged(int id)
    {
        RangedAttack returnVal = null;
        RangedList.ForEach(
            dodge => {
                if (RangedList.IndexOf(dodge) == id)
                { returnVal = dodge; }
            }
            );
        return returnVal;
    }

    public RangedAttack idToRanged(string id)
    {
        RangedAttack returnVal = null;
        RangedList.ForEach(
            dodge => {
                if (dodge.GetType().ToString() == id)
                { returnVal = dodge; }
            }
            );
        return returnVal;
    }

    public Special idToSpecial(int id)
    {
        Special returnVal = null;
        SpecialList.ForEach(
            dodge => {
                if (SpecialList.IndexOf(dodge) == id)
                { returnVal = dodge; }
            }
            );
        return returnVal;
    }

    public Special idToSpecial(string id)
    {
        Special returnVal = null;
        SpecialList.ForEach(
            dodge => {
                if (dodge.GetType().ToString() == id)
                { returnVal = dodge; }
            }
            );
        return returnVal;
    }

    public Parry idToParry(int id)
    {
        Parry returnVal = null;
        ParryList.ForEach(
            dodge => {
                if (ParryList.IndexOf(dodge) == id)
                { returnVal = dodge; }
            }
            );
        return returnVal;
    }

    public Parry idToParry(string id)
    {
        Parry returnVal = null;
        ParryList.ForEach(
            dodge => {
                if (dodge.GetType().ToString() == id)
                { returnVal = dodge; }
            }
            );
        return returnVal;
    }

    /* public Assist idToAssist(int id)
     {
         Assist returnVal = null;
         AssistList.ForEach(
             dodge => {
                 if (AssistList.IndexOf(dodge) == id)
                 { returnVal = dodge; }
             }
             );
         return returnVal;
     }

     public Assist idToAssist(string id)
     {
         Assist returnVal = null;
         AssistList.ForEach(
             dodge => {
                 if (dodge.GetType().ToString() == id)
                 { returnVal = dodge; }
             }
             );
         return returnVal;
     }*/
}
