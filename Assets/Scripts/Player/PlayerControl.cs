using System.Collections;
using System;
using UnityEngine;
using System.Collections.Generic;

public class PlayerControl : EntityControl
{
    [Header("Player")]
    //player data
    [SerializeField]
    internal PlayerData Player;
    [SerializeField]
    internal Camera cam;

    [Header("Loadout")]
    [SerializeField]
    internal LoadoutManager loadout;
    [SerializeField]
    internal Dodge dodgeMove;
    [SerializeField]
    internal MeleeAttack meleeAttack;
    [SerializeField]
    internal RangedAttack rangedAttack;
    [SerializeField]
    internal Special specialAttack;
    [SerializeField]
    internal Parry parryMove;

    [SerializeField]
    internal Assist assistMove;

    public GameObject facingObject => transform.Find("Facing").gameObject;
    public Transform MeleeAttackPoint => transform.Find("MeleeAttackPoint").gameObject.transform;
    public Transform RangedAttackPoint => transform.Find("RangedAttackPoint").gameObject.transform;


    public int bossID => GameObject.Find("Boss").GetComponent<BossData>().bossID;
    public bool bossDead => GameObject.Find("Boss").GetComponent<BossData>().isDead; 

    [Header("Game Events")]
    public GameEvent MeleeAttackEvent;

    [Header("Debug")]
    public bool verbose = false;
    public bool ControllerMode = false;
    public bool SCAvailable = false;
    public GameObject triggeredNPC;
    public bool triggeringNPC;

    //theres probably a way better way than this idk
    [Header("Game Progress")]
    public int[] bossesDefeated = new int[1] { 0 };
    public int[] dodgeUnlocked = new int[4] { 1, 0, 0, 0 };
    public int[] meleeUnlocked = new int[2] { 1, 0 };
    public int[] rangedUnlocked = new int[1] { 1 };
    public int[] specialUnlocked = new int[1] { 1 };
    public int[] parryUnlocked = new int[1] { 1 };
    public int[] assistUnlocked = new int[1] { 0 };

    private void Start()
    {
        Player.Reset();
        //just so we don't have to press L for errors to go away
        dodgeMove = dodgeMove == null ? loadout.DodgeList[0] : dodgeMove;
        meleeAttack = meleeAttack == null ? loadout.MeleeList[0] : meleeAttack;
        rangedAttack = rangedAttack == null ? loadout.RangedList[0] : rangedAttack;
        specialAttack = specialAttack == null ? loadout.SpecialList[0] : specialAttack;
        parryMove = parryMove == null ? loadout.ParryList[0] : parryMove;
    }

    // Update is called once per frame
    void Update()
    {
        Player.StaminaRegen();
        //sets player orientation = to mouse position
        if (Input.mousePosition.x >= 0 && Input.mousePosition.y >= 0 && Input.mousePosition.x <= Screen.width && Input.mousePosition.y <= Screen.height && !ControllerMode)
        {
            Cursor.lockState = CursorLockMode.None;
            orientationVector = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));
            Vector2 orientationVector2D = new Vector2(orientationVector.x, orientationVector.y);
            Vector2 facing = (((orientationVector2D - rb.position) * 500).normalized);

            //update melee/ranged attack points
            try
            {
                MeleeAttackPoint.position = rb.position + meleeAttack.attackRange * facing;
                RangedAttackPoint.position = rb.position + 1f * facing;
            }
            catch (Exception e)
            {
                // Debug.LogError(e);
            }

            //set the facing child object to facing
            facingObject.transform.position = facing;

        }
        else if (ControllerMode)
        {
            Cursor.lockState = CursorLockMode.Locked;
            orientationVector.x += Input.GetAxisRaw("Mouse X");
            orientationVector.y += Input.GetAxisRaw("Mouse Y");
            if (orientationVector.x >= 20) orientationVector.x = 20;
            if (orientationVector.x <= -20) orientationVector.x = -20;
            if (orientationVector.y >= 20) orientationVector.y = 20;
            if (orientationVector.y <= -20) orientationVector.y = -20;
            Vector2 facing = orientationVector.normalized;
            try
            {
                MeleeAttackPoint.position = rb.position + meleeAttack.attackRange * facing;
                RangedAttackPoint.position = rb.position + 1f * facing;
            }
            catch (Exception e)
            {
                // Debug.LogError(e);
            }

            //set the facing child object to facing
            facingObject.transform.position = facing;
        }
        if (canAct)
        {

            //Movement control
            movementVector.x = Input.GetAxisRaw("Horizontal");
            movementVector.y = Input.GetAxisRaw("Vertical");
            movementVector.z = 0;


            // Flip Sprite render x axis when switching directions
            if (Input.GetAxis("Horizontal") > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }




            animator.SetFloat("Horizontal", movementVector.x);
            animator.SetFloat("Vertical", movementVector.y);
            animator.SetFloat("Speed", movementVector.sqrMagnitude);

            rb.MovePosition(rb.position + new Vector2(movementVector.x, movementVector.y).normalized * Player.speed * Time.fixedDeltaTime);
            rb.velocity = Vector3.zero;

            //Input processing (XBOX controller scheme)
            if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown("joystick button 0")) //a
            {
                MeleeAttack();
            }
            else if (Input.GetKeyDown(KeyCode.Mouse1) || Input.GetKeyDown("joystick button 5")) //right bumper
            {
                RangedAttack();
            }
            else if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown("joystick button 1")) //b
            {
                Dodge();
            }
            else if (Input.GetKeyDown(KeyCode.F) ||  Input.GetKeyDown("joystick button 4")) //left bumper
            {
                Assist();
            }
            else if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown("joystick button 3")) //y
            {
                Special();
            }
            else if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown("joystick button 2")) //x
            {
                Parry();
            }
            else if (Input.GetKeyDown(KeyCode.O))
            {
                SaveGame();
            }
            else if (Input.GetKeyDown(KeyCode.P))
            {
                LoadGame();
            }
            //this "L" button is just for testing the loadout
            else if (Input.GetKeyDown(KeyCode.L))
            {
                ChangeLoadout();
            }
            else if (Input.GetKeyDown(KeyCode.Space) && bossDead) {
                SpareOrConsumeBoss();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1) && SCAvailable) {
                SpareBoss();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) && SCAvailable) {
                ConsumeBoss();
            }
        }
        else
        {
            // prevents Player from attacking consecutively without cooldown
            if(!isDisabled)
            {
                cooldown -= Time.deltaTime;
                if (cooldown <= 0)
                {
                    animator.SetBool("isMeleeAttacking", false);
                    animator.SetBool("isRangedAttacking", false);
                    canAct = true;
                }
            }
        }

    }


    public void FindCamera()
    {
        cam = Camera.main;
    }

    public void MoveToRespawnPoint()
    {
        transform.position = GameObject.Find("Respawn Point").transform.position;
    }

    public void movePlayer(Vector3 moveVector)
    {
        transform.position += moveVector;
    }

    public void bossDied()
    {
        bossesDefeated.SetValue(1, bossID);
    }

    public void UnlockDodge(int id) {dodgeUnlocked.SetValue(1, id);}
    public void UnlockMelee(int id){meleeUnlocked.SetValue(1, id);}
    public void UnlockRanged(int id) { rangedUnlocked.SetValue(1, id);}
    public void UnlockSpecial(int id) { specialUnlocked.SetValue(1, id);}
    public void UnlockParry(int id) { parryUnlocked.SetValue(1, id);}
    public void UnlockAssist(int id) { assistUnlocked.SetValue(1, id);}

    public void changeButton(Button button)
    {
        if (button is MeleeAttack) meleeAttack = (MeleeAttack)button;
        if (button is RangedAttack) rangedAttack = (RangedAttack)button;
        if (button is Special) specialAttack = (Special)button;
        if (button is Dodge) dodgeMove = (Dodge)button;
        if (button is Parry) parryMove = (Parry)button;
        if (button is MeleeAttack) meleeAttack = (MeleeAttack)button;
        if (button is Assist) assistMove = (Assist)button;
    }

    //saves the game for player
    void SaveGame()
    {
        SaveLoad.Save(this);
        if(verbose) Debug.Log("Saved game!");
    }

    //loads the game for player
    void LoadGame()
    {
        SaveData save = SaveLoad.Load();
        dodgeMove = loadout.DodgeList[save.dodge];
        meleeAttack = loadout.MeleeList[save.meleeAttack];
        rangedAttack = loadout.RangedList[save.rangedAttack];
        specialAttack = loadout.SpecialList[save.specialAttack];
        parryMove = loadout.ParryList[save.parry];
        assistMove = loadout.AssistList[save.assist];

        bossesDefeated = save.bossesDefeated;
        dodgeUnlocked = save.dodgeUnlocked;
        meleeUnlocked = save.meleeUnlocked;
        rangedUnlocked = save.rangedUnlocked;
        specialUnlocked = save.specialUnlocked;
        parryUnlocked = save.parryUnlocked;
        assistUnlocked = save.assistUnlocked;
        if (verbose) Debug.Log("Loaded game!");
    }

    // Player Melee Attack
    void MeleeAttack()
    {
        cooldown = meleeAttack.cooldown;
        meleeAttack.attack();
        MeleeAttackEvent.Raise();
        canAct = false;
        animator.SetFloat("Speed", 0);
        if (verbose) Debug.Log("MeleeAttack");
    }


    // Player Ranged Attack
    void RangedAttack()
    {
        Player.ReduceStamina(rangedAttack.staminaCost);
        cooldown = rangedAttack.cooldown;
        rangedAttack.attack();
        canAct = false;
        animator.SetFloat("Speed", 0);
        if (verbose) Debug.Log("RangedAttack");
    }


    // Player Dodge Attack
    void Dodge()
    {
        // Play dodge animation
        // Move character in direction of dodge
        if (Player.currentStamina > 0) {

            cooldown = (dodgeMove.cooldown);
            dodgeMove.PerformDodge();
            Player.ReduceStamina(dodgeMove.staminaCost);
            canAct = false;
            if (verbose) Debug.Log("Dodge");

        }
    }

    void Assist()
    {
        //Assist animation occurs
        //Assisting character joins screen
        assistMove.spawn();
        //leave this for later
        if (verbose) Debug.Log("Assist");
    }

    //Player Special
    void Special()
    {
        if (Player.currentStamina > 0)
        { 
            cooldown = specialAttack.cooldown;
            Player.ReduceStamina(specialAttack.staminaCost);
            animator.SetFloat("Speed", 0);
            specialAttack.special();
            canAct = false;
            if (verbose) Debug.Log("Special");
        }
    }

    //Player Parry
    void Parry()
    {
        Player.ReduceStamina(parryMove.staminaCost);
        //Parry animation occurs
        //Frame of invulnerability with ending lag
        cooldown = (parryMove.cooldown);
        parryMove.parry();
        canAct = false;
        if (verbose) Debug.Log("Parry");
    }

    void ChangeLoadout()
    {
        //currently all changes to loadout must be done already knowing what type of button to change, idk if this is too hardcoded or not
        //possible to change loadout by supplying ID
        if (dodgeUnlocked[2] == 1)
        {
            changeButton(loadout.idToDodge(2));
            if (verbose) Debug.Log("Loadout Changed: " + loadout.idToDodge(2).ToString() );
        }
        else if (verbose) Debug.Log( String.Format( "This dodge {0} is not unlocked!", loadout.idToDodge(2).ToString() ) );

        //possible to check loadout by supplying string
        string checkForThis = "Dodge_Backflip";
        if ( dodgeUnlocked[ loadout.DodgeList.IndexOf( loadout.idToDodge(checkForThis) )] == 1 )
        {
            changeButton(loadout.idToDodge(checkForThis));
            if (verbose) Debug.Log("Loadout Changed: " + loadout.idToDodge(checkForThis));
        }
        else if (verbose) Debug.Log(String.Format("This dodge {0} is not unlocked!", loadout.idToDodge(checkForThis).ToString()));

        if (meleeUnlocked[1] == 1)
        {
            changeButton(loadout.idToMelee(1));
            if (verbose) Debug.Log("Loadout Changed: " + loadout.idToMelee(1));
        }
        else if (verbose) Debug.Log(String.Format("This dodge {0} is not unlocked!", loadout.idToMelee(1).ToString()));
    }

    void SpareOrConsumeBoss() {
        if (triggeringNPC) {
            // Anyone want to change this to say something more dramatic?
            Debug.Log("RAIMUND: You have bested me.");
            Debug.Log("Would you like to SPARE or CONSUME RAIMUND?");
            Debug.Log("1 : Spare | 2 : Consume"); 
            SCAvailable = true;
        }
    }

    void SpareBoss() {
        if (triggeringNPC) {
            UnlockAssist(bossID);
            assistMove = assistMove == null ? loadout.AssistList[bossID] : assistMove;
            Debug.Log("RAIMUND has been spared and will be here to assist you in your further battles!");
            StartCoroutine(Player.LoadAsyncScene(Player.RespawnScene));
            SCAvailable = false;
        }

    }

    void ConsumeBoss() {
        if (triggeringNPC) {
            UnlockMelee(bossID + 1);
            UnlockRanged(bossID + 1);
            Debug.Log("RAIMUND was consumed, you have been granted RAIMUND's abilities!");
            StartCoroutine(Player.LoadAsyncScene(Player.RespawnScene));
            SCAvailable = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "NPC") {
            triggeringNPC = true;
            triggeredNPC = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "NPC") {
            triggeringNPC = false;
            triggeredNPC = null;
        }
    }
}
