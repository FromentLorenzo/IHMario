using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSotomanager : MonoBehaviour
{
    private Animator mAnimator;
    private float timer;
    private float triWendigoDuration = 2f;
    private float triTireDuration = 0f;
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

            if (timer >= triTireDuration && currentAnimation == 0)
            {
                mAnimator.SetTrigger("tri-tire");
                currentAnimation++;
            }
            else if (timer >= triWendigoDuration && currentAnimation == 1)
            {
                mAnimator.SetTrigger("tri-wendigo");
                timer = 0f;
                currentAnimation++;

            }
        }
    }
}
