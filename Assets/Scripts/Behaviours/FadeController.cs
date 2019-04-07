using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class FadeController : MonoBehaviour
{
    public GameObject fadeTarget;
    public GameObject character;
    public Transform exitTrigger;

    private SpriteRenderer targetRenderer;
    private bool triggerOnFadeIn;
    private bool triggerOnFadeOut;

    void Start()
    {
        targetRenderer = fadeTarget.GetComponent<SpriteRenderer>();
        FadeIn();
    }

    void FixedUpdate()
    {
        if (character.transform.position.x > exitTrigger.position.x)
            FadeOut();
        
        if (triggerOnFadeIn && targetRenderer.color.a == 0)
            OnFadeIn();
        if (triggerOnFadeOut && targetRenderer.color.a == 1)
            OnFadeOut();
    }

    private void FadeIn()
    {
        triggerOnFadeIn = true;
        ExecuteEvents.Execute<IFadeListener>(fadeTarget, null, (x, y) => x.StartFadeIn());
    }

    private void FadeOut()
    {
        triggerOnFadeOut = true;
        ExecuteEvents.Execute<IFadeListener>(fadeTarget, null, (x, y) => x.StartFadeOut());
    }

    private void OnFadeIn()
    {
        triggerOnFadeIn = false;
    }

    private void OnFadeOut()
    {
        triggerOnFadeOut = false;
        SceneManager.LoadScene("Intro", LoadSceneMode.Single);
    }
}
