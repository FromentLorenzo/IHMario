using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBasketAnimation : MonoBehaviour
{
    private Animator mAnimator;
    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(mAnimator != null)
        {
            if(Input.GetKeyDown(KeyCode.O))
            {
                Debug.Log("tri-ball");
                mAnimator.SetTrigger("tri-ball");
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                Debug.Log("tri-baske");
                mAnimator.SetTrigger("tri-baske");
            }
        }
    }
}
