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
        
    }

    public void pushTitleGo()
    {
        topViewAnimator.SetBool("up", !topViewAnimator.GetBool("up"));
    }
}
