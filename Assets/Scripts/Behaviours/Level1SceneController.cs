using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Level1SceneController : MonoBehaviour
{
    public GameObject fadeTarget;
    public GameObject character;
    public Transform exitTrigger;

    private SpriteRenderer targetRenderer;

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
        targetRenderer = fadeTarget.GetComponent<SpriteRenderer>();
        Commands.FireFadeIn();
    }

    void FixedUpdate()
    {
        if (character.transform.position.x > exitTrigger.position.x)
            Commands.FireFadeOut();
    }

    private void OnFadeOutFinished()
    {
        SceneManager.LoadScene("Intro");
    }
}
