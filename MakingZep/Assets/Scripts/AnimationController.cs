using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : Animation
{
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");


    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        controller.OnMoveEvent += Move;
    }

    private void Move(Vector2 obj)
    {
        animator.SetBool(IsWalking, obj.magnitude > .5f);
    }
}
