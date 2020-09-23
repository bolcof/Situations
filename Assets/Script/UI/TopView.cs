using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopView : MonoBehaviour
{
    public int state = 0;/* 0:title, 1:stage select*/
    private Animator topViewAnimator;

    void Start()
    {
        topViewAnimator = GameObject.Find("topView").GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && topViewAnimator.GetBool("up")) {
            pushTitleGo();
        }
    }

    public void pushTitleGo()
    {
        //topViewAnimator.SetBool("up", !topViewAnimator.GetBool("up"));

        GameObject.Find("BlackFade").GetComponent<BlackFade>().isFadingOn = true;
    }
}
