using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{
    public string sceneName;

    void Update()
    {
        if (Input.GetButtonDown("Reset"))
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
