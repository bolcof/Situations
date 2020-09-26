using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Digree : MonoBehaviour
{
    [SerializeField]
    private float start, duration;

    [SerializeField]
    private float digX, digY;

    private bool isDigreeing = false;
    private bool digStarted = false;

    public float digTime;
    private float digCount = 0.0f;

    public VideoPlayer backVideo;

    void Update()
    {
        if(backVideo.time > start + duration && isDigreeing)
        {
            isDigreeing = false;
            this.gameObject.transform.position = new Vector3(0.0f, 0.0f, -10.0f);
        }
        else if(backVideo.time > start && !digStarted)
        {
            isDigreeing = true;
            digStarted = true;
        }

        if (isDigreeing)
        {
            digCount += Time.deltaTime;
            if(digCount > digTime)
            {
                digCount -= digTime;
                this.gameObject.transform.position = new Vector3(Random.Range(-digX, digX), Random.Range(-digY, digY), -10.0f);
            }
        }
    }
}
