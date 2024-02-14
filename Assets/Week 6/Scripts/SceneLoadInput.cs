using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoadInput : MonoBehaviour
{
    public SceneLoader SceneLoaderInstance;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneLoaderInstance.LoadNextScene();
        }
    }
}
