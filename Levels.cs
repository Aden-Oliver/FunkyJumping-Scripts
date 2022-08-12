using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    public AudioSource audio;
    public void LevelOne ()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void LevelTwo()
    {
        SceneManager.LoadScene("Level_2");
    }

    public void LevelThree()
    {
        SceneManager.LoadScene("Level_3");
    }
    public void StartMenu()
    {
        SceneManager.LoadScene("Start_Menu");
    }

    public void PlayClick()
    {
        audio.Play();
    }
}
