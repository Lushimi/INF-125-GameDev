using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Load call works, cannot test because saving in-game brings up a file request screen (bug?)
//No idea why background color on game and scene don't match
//Buttons do not drag properly and dimensions are wonky 

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("Starting game");
        //Put intro cutscene (introducing bigknight) by alex
        SceneManager.LoadSceneAsync("IntroCutscene");
        //Instantiate player
        //StartCoroutine(PlayerData.LoadAsyncScene()); (when working)
    }

    public void LoadGame()
    {
        Debug.Log("Loading game");
        //Put loaded file onto player
        SaveLoad.Load();
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game");
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    } 
}
 