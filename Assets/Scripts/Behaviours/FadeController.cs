using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : MonoBehaviour
{
    public float delay;

    private enum FadeType { FadeIn, FadeOut };
    private FadeType type = FadeType.FadeIn;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool newFadeFinish;

    void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnValidate()
    {
        delay = Mathf.Max(delay, 0);
    }

    void OnEnable()
    {
        Commands.FadeIn += StartFadeIn;
        Commands.FadeOut += StartFadeOut;
    }

    void OnDisable()
    {
        Commands.FadeIn -= StartFadeIn;
        Commands.FadeOut -= StartFadeOut;
    }

    void FixedUpdate()
    {
        CheckFinishedStatus();
    }

    private void StartFadeIn()
    {
        type = FadeType.FadeIn;
        InitializeFade();
    }

    private void StartFadeOut()
    {
        type = FadeType.FadeOut;
        InitializeFade();
    }

    private void InitializeFade()
    {
        // Scale in editor is (0, 0, 1) to hide it
        // Set it big enough to cover the camera
        transform.localScale = new Vector3(4000, 3000, 1);
        newFadeFinish = true;
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

    private void CheckFinishedStatus()
    {
        if (!newFadeFinish)
            return;

        newFadeFinish = false;
        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
        if (info.IsName("FadeInFinished"))
            Signals.EmitFadeInFinished();
        else if (info.IsName("FadeOutFinished"))
            Signals.EmitFadeOutFinished();
        else
            newFadeFinish = true;
    }
}
