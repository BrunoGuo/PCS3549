using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationOverrideController : MonoBehaviour
{
    private Animator _animator;

    private void Awake() {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void SetAnimations(AnimatorOverrideController overrideController)
    {
        _animator.runtimeAnimatorController = overrideController;
    }
}
