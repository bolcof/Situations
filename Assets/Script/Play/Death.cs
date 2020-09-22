using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Death : MonoBehaviour
{
    [SerializeField]
    private float DeadLine, toNextScene;

    [SerializeField]
    private string nextScene;

    private float time;

    void Start()
    {
        time = 0.0f;
    }
    void Update()
    {
        time += Time.deltaTime;
        if(time > DeadLine + toNextScene)
        {
            SceneManager.LoadScene(nextScene);
        }
        else if(time > DeadLine)
        {
            this.gameObject.GetComponent<Image>().enabled = true;
        }
    }
}
