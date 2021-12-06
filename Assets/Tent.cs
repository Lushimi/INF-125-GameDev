using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tent : MonoBehaviour
{
    [SerializeField]
    public GameObject lul;
    public GameObject dodgeChange;
    public GameObject dodgeButton;
    public GameObject dodgeBackButton;
    public GameObject dodgeIcon;
    public GameObject dodgeText;

    public GameObject assistChange;
    public GameObject assistButton;
    public GameObject assistBackButton;
    public GameObject assistIcon;
    public GameObject assistText;

    public GameObject meleeChange;
    public GameObject meleeButton;
    public GameObject meleeBackButton;
    public GameObject meleeIcon;
    public GameObject meleeText;

    public GameObject parryChange;
    public GameObject parryButton;
    public GameObject parryBackButton;
    public GameObject parryIcon;
    public GameObject parryText;

    public GameObject rangedChange;
    public GameObject rangedButton;
    public GameObject rangedBackButton;
    public GameObject rangedIcon;
    public GameObject rangedText;

    public GameObject specialChange;
    public GameObject specialButton;
    public GameObject specialBackButton;
    public GameObject specialIcon;
    public GameObject specialText;


    //onCollide 

    void Start()
    {
        lul.SetActive(false);

        dodgeChange.SetActive(false);
        dodgeButton.SetActive(false);
        dodgeBackButton.SetActive(false);
        dodgeIcon.SetActive(false);
        dodgeText.SetActive(false);

        assistChange.SetActive(false);
        assistButton.SetActive(false);
        assistBackButton.SetActive(false);
        assistIcon.SetActive(false);
        assistText.SetActive(false);

        meleeChange.SetActive(false);
        meleeButton.SetActive(false);
        meleeBackButton.SetActive(false);
        meleeIcon.SetActive(false);
        meleeText.SetActive(false);

        parryChange.SetActive(false);
        parryButton.SetActive(false);
        parryBackButton.SetActive(false);
        parryIcon.SetActive(false);
        parryText.SetActive(false);

        rangedChange.SetActive(false);
        rangedButton.SetActive(false);
        rangedBackButton.SetActive(false);
        rangedIcon.SetActive(false);
        rangedText.SetActive(false);

        specialChange.SetActive(false);
        specialButton.SetActive(false);
        specialBackButton.SetActive(false);
        specialIcon.SetActive(false);
        specialText.SetActive(false);
    }
    
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        lul.SetActive(true);

        dodgeChange.SetActive(true);
        dodgeButton.SetActive(true);
        dodgeBackButton.SetActive(true);
        dodgeIcon.SetActive(true);
        dodgeText.SetActive(true);

        assistChange.SetActive(true);
        assistButton.SetActive(true);
        assistBackButton.SetActive(true);
        assistIcon.SetActive(true);
        assistText.SetActive(true);

        meleeChange.SetActive(true);
        meleeButton.SetActive(true);
        meleeBackButton.SetActive(true);
        meleeIcon.SetActive(true);
        meleeText.SetActive(true);

        parryChange.SetActive(true);
        parryButton.SetActive(true);
        parryBackButton.SetActive(true);
        parryIcon.SetActive(true);
        parryText.SetActive(true);

        rangedChange.SetActive(true);
        rangedButton.SetActive(true);
        rangedBackButton.SetActive(true);
        rangedIcon.SetActive(true);
        rangedText.SetActive(true);

        specialChange.SetActive(true);
        specialButton.SetActive(true);
        specialBackButton.SetActive(true);
        specialIcon.SetActive(true);
        specialText.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D hitInfo)
    {
        lul.SetActive(false);

        //Debug.Log("Exited!");
        dodgeChange.SetActive(false);
        dodgeButton.SetActive(false);
        dodgeBackButton.SetActive(false);
        dodgeIcon.SetActive(false);
        dodgeText.SetActive(false);

        assistChange.SetActive(false);
        assistButton.SetActive(false);
        assistBackButton.SetActive(false);
        assistIcon.SetActive(false);
        assistText.SetActive(false);

        meleeChange.SetActive(false);
        meleeButton.SetActive(false);
        meleeBackButton.SetActive(false);
        meleeIcon.SetActive(false);
        meleeText.SetActive(false);

        parryChange.SetActive(false);
        parryButton.SetActive(false);
        parryBackButton.SetActive(false);
        parryIcon.SetActive(false);
        parryText.SetActive(false);

        rangedChange.SetActive(false);
        rangedButton.SetActive(false);
        rangedBackButton.SetActive(false);
        rangedIcon.SetActive(false);
        rangedText.SetActive(false);

        specialChange.SetActive(false);
        specialButton.SetActive(false);
        specialBackButton.SetActive(false);
        specialIcon.SetActive(false);
        specialText.SetActive(false);
    }

}


