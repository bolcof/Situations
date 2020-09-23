using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWall : MonoBehaviour
{
    [SerializeField]
    private int stage = 0;

    private float time = 0.0f;

    [SerializeField]
    private GameObject Left, Right;

    [SerializeField]
    private float[] leftWallPos = new float[4];
    [SerializeField]
    private float[] rightWallPos = new float[4];

    void Start()
    {
        
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time > 40.0f)
        {
            stage = 3;
            Left.transform.position = new Vector3(leftWallPos[stage], 0.0f, 0.0f);
            Right.transform.position = new Vector3(rightWallPos[stage], 0.0f, 0.0f);

        }
        else if (time > 25.0f)
        {
            stage = 2;
            Left.transform.position = new Vector3(leftWallPos[stage], 0.0f, 0.0f);
            Right.transform.position = new Vector3(rightWallPos[stage], 0.0f, 0.0f);
        }
        else if (time > 10.0f)
        {
            stage = 1;
            Left.transform.position = new Vector3(leftWallPos[stage], 0.0f, 0.0f);
            Right.transform.position = new Vector3(rightWallPos[stage], 0.0f, 0.0f);
        }
    }
}
