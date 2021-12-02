using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
    public string SceneChangeName;
    public GameObject Player => GameObject.Find("Player");

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerData playerHit = hitInfo.GetComponent<PlayerData>();
        // If an enemy was hit
        if (playerHit != null)
        {
            Debug.Log("Player went through: " + this.name);
            StartCoroutine( playerHit.LoadAsyncScene(SceneChangeName) );
        }
    }

}
