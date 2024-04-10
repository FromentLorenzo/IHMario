using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationLorenzoManager : MonoBehaviour
{
    private Animator mAnimator;
    private float timer;
    private float finnStart = 0f;
    private float pionStart = 0f;
    private float relancer = 14f;
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

            if(timer >= relancer)
            {
                timer = 0f;
                currentAnimation = 0;

            }

            if (timer >= finnStart && currentAnimation == 0)
            {
                mAnimator.SetTrigger("finnAnimationTrigger");
                currentAnimation++;
            }
            else if (timer >= pionStart && currentAnimation == 1)
            {
                mAnimator.SetTrigger("pionAnimationTrigger");
                currentAnimation++;
            }
        }
    }
}
