using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationLucieManager : MonoBehaviour
{
    private Animator mAnimator;
    private int frameNumber;

    // Start is called before the first frame update
    void Start()
    {
        frameNumber = 0;
        mAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (mAnimator != null)
        {
            /*if (Input.GetKeyDown(KeyCode.O))
            {
                mAnimator.SetTrigger("tri-chatte");
                Debug.Log("tri-chatte");
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                mAnimator.SetTrigger("tri-balle");
                Debug.Log("tri-balle");
            }*/

            if (frameNumber == 1600)
            {
                frameNumber = 0;
            }

            if (frameNumber == 0)
            {
                mAnimator.SetTrigger("tri-chatte");
                //Debug.Log("tri-chatte");

            }
            if (frameNumber == 600)
            {
                mAnimator.SetTrigger("tri-balle");
                //Debug.Log("tri-balle");

            }
            frameNumber++;
        }
            


    }
}
