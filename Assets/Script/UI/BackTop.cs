using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackTop : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) {
            GameObject.Find("BlackFade").GetComponent<BlackFade>().nextScene = "top";
            GameObject.Find("BlackFade").GetComponent<BlackFade>().isFadingOn = true;
        }
    }
}
