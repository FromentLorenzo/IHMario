using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationLorenzoManager : MonoBehaviour
{
    private Animator mAnimator;
    private float timer;
    private float isfinnDuration = 0f;
    private float triPionDuration = 9f;
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

            if (timer >= isfinnDuration && currentAnimation == 0)
            {
                mAnimator.SetTrigger("isfinn");
                timer = 0f;
                currentAnimation++;
            }
            else if (timer >= triPionDuration && currentAnimation == 1)
            {
                mAnimator.SetTrigger("tri-pion");
                currentAnimation++;
            }
        }
    }
}
