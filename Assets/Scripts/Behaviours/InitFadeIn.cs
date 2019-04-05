using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitFadeIn : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        // Scale in editor is (0, 0, 1) to hide it
        // Set it big enough to cover the camera
        transform.localScale = new Vector3(4000, 3000, 1);

        StartCoroutine(DelayedFadeIn());
    }

    private IEnumerator DelayedFadeIn()
    {
        yield return new WaitForSeconds(2);
        animator.SetBool("StartFadeIn", true);
    }
}
