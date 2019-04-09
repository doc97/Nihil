using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitFade : MonoBehaviour, IFadeListener
{
    public float delay;

    private enum FadeType { FadeIn, FadeOut };
    private FadeType type = FadeType.FadeIn;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnValidate()
    {
        delay = Mathf.Max(delay, 0);
    }

    public void StartFadeIn()
    {
        type = FadeType.FadeIn;
        InitializeFade();
    }

    public void StartFadeOut()
    {
        type = FadeType.FadeOut;
        InitializeFade();
    }

    private void InitializeFade()
    {
        // Scale in editor is (0, 0, 1) to hide it
        // Set it big enough to cover the camera
        transform.localScale = new Vector3(4000, 3000, 1);
        ResetParameters();
        ActivateStartParameter();
        Invoke("ActivateDelayedParameter", delay);
    }

    private void ResetParameters()
    {
        animator.ResetTrigger("StartFadeIn");
        animator.ResetTrigger("StartFadeOut");
        animator.ResetTrigger("DelayedFadeIn");
        animator.ResetTrigger("DelayedFadeOut");
    }

    private void ActivateStartParameter()
    {
        switch (type)
        {
            case FadeType.FadeIn:
                animator.SetTrigger("StartFadeIn");
                break;
            case FadeType.FadeOut:
                animator.SetTrigger("StartFadeOut");
                break;
        }
    }

    private void ActivateDelayedParameter()
    {
        switch (type)
        {
            case FadeType.FadeIn:
                animator.SetTrigger("DelayedFadeIn");
                break;
            case FadeType.FadeOut:
                animator.SetTrigger("DelayedFadeOut");
                break;
        }
    }
}
