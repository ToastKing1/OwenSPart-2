using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    int sceneIndex = 0;

    public void SceneChange()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex+1;
        if (sceneIndex == 4)
        {
            sceneIndex = 0;
        }
        SceneManager.LoadScene(sceneIndex);
    }
}
