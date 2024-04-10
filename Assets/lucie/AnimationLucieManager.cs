using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationLucieManager : MonoBehaviour
{
    private Animator mAnimator;
    private float timer;
    private float triChatteDuration = 0f;
    private float triBalleDuration = 3.5f;
    private float relancer = 8;
    private int currentAnimation;


    void Start()
    {
        timer = 0f;
        mAnimator = GetComponent<Animator>();
        currentAnimation = 0;
    }

    void Update()
    {
        if (mAnimator != null)
        {
            timer += Time.deltaTime;

            if (timer >= relancer)
            {
                timer = 0f;
                currentAnimation = 0;

            }

            if (timer >= triChatteDuration && currentAnimation == 0)
            {
                mAnimator.SetTrigger("tri-chatte");
                timer = 0f;
                currentAnimation++;
            }
            else if (timer >= triBalleDuration && currentAnimation == 1)
            {
                mAnimator.SetTrigger("tri-balle");
                currentAnimation++;
            }
        }
    }
}
