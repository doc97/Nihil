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

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
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
        animator = GetComponent<Animator>();
        // Scale in editor is (0, 0, 1) to hide it
        // Set it big enough to cover the camera
        transform.localScale = new Vector3(4000, 3000, 1);
        ResetParameters();
        ActivateStartParameter();
        StartCoroutine(DelayedFade());
    }

    private IEnumerator DelayedFade()
    {
        yield return new WaitForSeconds(delay);
        ActivateDelayedParameter();
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

    private void ValidateAlpha()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        if (renderer == null)
            return;
        switch (type)
        {
            case FadeType.FadeIn:
                SetAlpha(renderer, 1);
                break;
            case FadeType.FadeOut:
                SetAlpha(renderer, 0);
                break;
        }
    }

    private void SetAlpha(SpriteRenderer renderer, float a)
    {
        // Have to set both renderer.color and material.color for it to work
        renderer.color = new Color(1, 1, 1, a);
        renderer.material.color = new Color(1, 1, 1, a);
    }
}
