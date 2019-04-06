using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FadeController : MonoBehaviour
{
    public GameObject fadeInTarget;

    void Start()
    {
        FadeIn();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            FadeIn();
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            FadeOut();
        }
    }

    private void FadeIn()
    {
        ExecuteEvents.Execute<IFadeListener>(fadeInTarget, null, (x, y) => x.StartFadeIn());
    }

    private void FadeOut()
    {
        ExecuteEvents.Execute<IFadeListener>(fadeInTarget, null, (x, y) => x.StartFadeOut());
    }
}
