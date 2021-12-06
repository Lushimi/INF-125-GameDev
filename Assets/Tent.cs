using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tent : MonoBehaviour
{
    [SerializeField]
    public GameObject dodgeChange;
    public GameObject dodgeButton;
    public GameObject dodgeText;

    public GameObject assistChange;
    public GameObject assistButton;
    public GameObject assistText;

    public GameObject meleeChange;
    public GameObject meleeButton;
    public GameObject meleeText;

    public GameObject parryChange;
    public GameObject parryButton;
    public GameObject parryText;

    public GameObject rangedChange;
    public GameObject rangedButton;
    public GameObject rangedText;

    public GameObject specialChange;
    public GameObject specialButton;
    public GameObject specialText;


    //onCollide 

    void Start()
    {
        dodgeChange.SetActive(false);
        dodgeButton.SetActive(false);
        dodgeText.SetActive(false);

        assistChange.SetActive(false);
        assistButton.SetActive(false);
        assistText.SetActive(false);

        meleeChange.SetActive(false);
        meleeButton.SetActive(false);
        meleeText.SetActive(false);

        parryChange.SetActive(false);
        parryButton.SetActive(false);
        parryText.SetActive(false);

        rangedChange.SetActive(false);
        rangedButton.SetActive(false);
        rangedText.SetActive(false);

        specialChange.SetActive(false);
        specialButton.SetActive(false);
        specialText.SetActive(false);
    }
    
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        dodgeChange.SetActive(true);
        dodgeButton.SetActive(true);
        dodgeText.SetActive(true);

        assistChange.SetActive(true);
        assistButton.SetActive(true);
        assistText.SetActive(true);

        meleeChange.SetActive(true);
        meleeButton.SetActive(true);
        meleeText.SetActive(true);

        parryChange.SetActive(true);
        parryButton.SetActive(true);
        parryText.SetActive(true);

        rangedChange.SetActive(true);
        rangedButton.SetActive(true);
        rangedText.SetActive(true);

        specialChange.SetActive(true);
        specialButton.SetActive(true);
        specialText.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D hitInfo)
    {
        //Debug.Log("Exited!");
        dodgeChange.SetActive(false);
        dodgeButton.SetActive(false);
        dodgeText.SetActive(false);

        assistChange.SetActive(false);
        assistButton.SetActive(false);
        assistText.SetActive(false);

        meleeChange.SetActive(false);
        meleeButton.SetActive(false);
        meleeText.SetActive(false);

        parryChange.SetActive(false);
        parryButton.SetActive(false);
        parryText.SetActive(false);

        rangedChange.SetActive(false);
        rangedButton.SetActive(false);
        rangedText.SetActive(false);

        specialChange.SetActive(false);
        specialButton.SetActive(false);
        specialText.SetActive(false);
    }

}


