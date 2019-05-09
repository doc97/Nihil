using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuSceneController : MonoBehaviour
{
    void OnEnable()
    {
        Signals.OnPlayRequested += OnPlay;
        Signals.OnQuitRequested += OnQuit;
    }

    void OnDisable()
    {
        Signals.OnPlayRequested -= OnPlay;
        Signals.OnQuitRequested -= OnQuit;
    }

    private void OnPlay()
    {
        SceneManager.LoadScene("Intro");
    }

    private void OnQuit()
    {
        // Does not quit when testing in Unity Editor or Web Player
        Application.Quit();
    }
}
