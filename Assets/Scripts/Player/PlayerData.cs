using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[Serializable]
public class PlayerData : EntityData
{
    public GameEvent DodgeSFX;
    public GameEvent NegativeStaminaToggle;
    public bool NegativeStaminaBool = false;

    [Header("Specific For Player")]
    public string RespawnScene = "HubScene";
    public bool isInitialized = false;
    private GameObject Player => gameObject;

    public override void Reset()
    {
        currentHealth = maxHP;
        HealthReset.Raise();
        currentStamina = maxStamina;
        StaminaChanged.Raise();
        speed = 5.5f;
        staminaPerSecond = 30f;
        GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
        isInitialized = true;
    }

    public override void TakeDamage(int damage)
    {
        if (isInvulnerable)
        {
            DodgedDamage();
        }
        base.TakeDamage(damage);
    }

    public override void TakeDamage(int damage, GameObject attacker)
    {
        if (isInvulnerable)
        {
            DodgedDamage();
        }
        base.TakeDamage(damage, attacker);
    }

    public void HealthRegen()
    {
        currentHealth += 10;
        HealthChanged.Raise();
    }
    
    public override void StaminaRegen()
    {
        base.StaminaRegen();
        if (currentStamina < 0 && NegativeStaminaBool == false)
        {
            NegativeStaminaToggle.Raise();
            NegativeStaminaBool = true;
        }
        else if (currentStamina >= 0 && NegativeStaminaBool == true)
        {
            NegativeStaminaToggle.Raise();
            NegativeStaminaBool = false;
        }
    }


    private void DodgedDamage()
    {
        DodgeSFX.Raise();
    }

    public override void Die()
    {
        Debug.Log("Player died!");
        // Die Animation
        Death.Raise();
        StartCoroutine(LoadAsyncScene(RespawnScene));
        Reset();
    }

    public void PortalChange(string sceneChange)
    {
        StartCoroutine( LoadAsyncScene(sceneChange) );
    }

    // from this tutorial https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.MoveGameObjectToScene.html
    public IEnumerator LoadAsyncScene(string sceneChange) 
    {
        Scene currentScene = SceneManager.GetActiveScene();
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneChange, LoadSceneMode.Additive);
        //AsyncOperation asyncLoad = EditorSceneManager.LoadSceneAsyncInPlayMode(sceneChange, new LoadSceneParameters(LoadSceneMode.Additive) );
        Debug.Log("Loaded 2nd Scene");
        //wait until it's fully loaded
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        //move player to newly loaded scene
        SceneManager.MoveGameObjectToScene(Player, SceneManager.GetSceneByName(sceneChange));
        Debug.Log("Moved Player");
        // Unload the previous Scene
        asyncLoad = SceneManager.UnloadSceneAsync(currentScene);
        Debug.Log("Unloaded 1st Scene");

        //wait till the previous scene is unloaded
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // raise game event
        Debug.Log("Done Loading");
        SceneChanged.Raise();

    }
}
