using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Level1SceneController : MonoBehaviour
{
    void OnEnable()
    {
        Signals.OnFadeOutFinished += OnFadeOutFinished;
    }

    void OnDisable()
    {
        Signals.OnFadeOutFinished -= OnFadeOutFinished;
    }

    void Start()
    {
        Commands.FireFadeIn();
    }

    private void OnFadeOutFinished()
    {
        SceneManager.LoadScene("Intro");
    }
}
