using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceneController : MonoBehaviour, IStatusFinished
{
    public void OnFinish()
    {
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }
}
