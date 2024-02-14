using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionChanger : MonoBehaviour
{
    public void ChangeAspectRatio(bool HD)
    {
        if (!HD)
        {
            Screen.SetResolution(1600, 900, false);
        }
        else
        {
            Screen.SetResolution(1920, 1080, false);
        }
    }


}
