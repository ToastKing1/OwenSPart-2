using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // variable to store the scene index
    int sceneIndex = 0;
    // this method loads the scene
    public void SceneChange()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex+1;
        // if the scene is the lose screen, it changes back to menu
        if (sceneIndex == 4)
        {
            sceneIndex = 0;
        }
        SceneManager.LoadScene(sceneIndex);
    }
}
