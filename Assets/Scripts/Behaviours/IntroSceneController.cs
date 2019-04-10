using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceneController : MonoBehaviour
{
    void OnEnable()
    {
        Signals.OnIntroFinished += SwitchScene;
    }

    void OnDisable()
    {
        Signals.OnIntroFinished -= SwitchScene;
    }

    private void SwitchScene()
    {
        SceneManager.LoadScene("Level1");
    }
}
