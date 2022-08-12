using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource audio;
    public void QuitGame ()
    {
        Application.Quit();
    }

    public void PlayClick()
    {
        audio.Play();
    }
}