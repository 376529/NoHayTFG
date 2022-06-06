using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Exit : MonoBehaviour
{
    public void QuitApplication(){

        EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
