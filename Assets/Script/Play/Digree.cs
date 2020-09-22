using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Digree : MonoBehaviour
{
    [SerializeField]
    private float start, duration;

    [SerializeField]
    private float digX, digY;

    private float time = 0.0f;
    private bool isDigreeing = false;

    public float digTime;
    private float digCount = 0.0f;

    void Update()
    {
        time += Time.deltaTime;
        if(time > start+ duration)
        {
            isDigreeing = false;
            this.gameObject.transform.position = new Vector3(0.0f, 0.0f, -10.0f);
            time = -100000.0f;
        }
        else if(time > start)
        {
            isDigreeing = true;
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
