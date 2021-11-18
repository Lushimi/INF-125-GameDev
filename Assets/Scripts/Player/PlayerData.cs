using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class PlayerData : EntityData
{
    public string RespawnScene = "HubScene";
    private GameObject Player => gameObject;
    [Header("Audio")]
    public AudioSource dodgeSFX;
    public override void Reset()
    {
        currentHealth = maxHP;
        HealthChanged.Raise();
        currentStamina = maxStamina;
        StaminaChanged.Raise();
        speed = 6f;
        staminaPerSecond = 17f;

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

    private void DodgedDamage()
    {
        dodgeSFX.Play();
    }

    public override void Die()
    {
        Debug.Log("Player died!");
        // Die Animation
        Death.Raise();
        StartCoroutine(LoadAsyncScene());
    }

    // from this tutorial https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.MoveGameObjectToScene.html
    IEnumerator LoadAsyncScene() 
    {
        Scene currentScene = SceneManager.GetActiveScene();
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(RespawnScene, LoadSceneMode.Additive);

        //wait until it's fully loaded
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        //move player to newly loaded scene
        SceneManager.MoveGameObjectToScene(Player, SceneManager.GetSceneByName(RespawnScene));
        // Unload the previous Scene
        asyncLoad = SceneManager.UnloadSceneAsync(currentScene);

        //wait till the previous scene is unloaded
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // raise game event
        SceneChanged.Raise();
        Reset();
    }
}
