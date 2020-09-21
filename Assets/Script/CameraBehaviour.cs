using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    private GameObject PlayerObj;
    private PlayerBehaviour PlayerB;
    private Vector3 CameraPos;

    [SerializeField]
    private float followLine, UnfollowLine;

    void Start()
    {
        PlayerObj = GameObject.Find("Player");
        PlayerB = PlayerObj.GetComponent<PlayerBehaviour>();
        CameraPos = this.gameObject.transform.position;
    }

    void Update()
    {
        float PlayerX = PlayerObj.transform.position.x;
        float CameraX = this.gameObject.transform.position.x;

        if((PlayerX - CameraX) <= -followLine)
        {
            Vector3 tmp = new Vector3(PlayerX + followLine, CameraPos.y, CameraPos.z);
            if(tmp.x <= -UnfollowLine) { tmp.x = -UnfollowLine; }
            this.gameObject.transform.position = tmp;
        }
        else if((PlayerX - CameraX) >= followLine)
        {
            Vector3 tmp = new Vector3(PlayerX - followLine, CameraPos.y, CameraPos.z);
            if (tmp.x >= UnfollowLine) { tmp.x = UnfollowLine; }
            this.gameObject.transform.position = tmp;
        }
    }
}
