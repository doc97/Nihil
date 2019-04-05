using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitFadeIn : MonoBehaviour
{
    public float delay;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        // Scale in editor is (0, 0, 1) to hide it
        // Set it big enough to cover the camera
        transform.localScale = new Vector3(4000, 3000, 1);

        StartCoroutine(DelayedFadeIn());
    }

    void OnValidate()
    {
        delay = Mathf.Max(delay, 0);
    }

    private IEnumerator DelayedFadeIn()
    {
        yield return new WaitForSeconds(delay);
        animator.SetBool("StartFadeIn", true);
    }
}
