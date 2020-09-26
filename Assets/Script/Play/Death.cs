using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class Death : MonoBehaviour
{
    [SerializeField]
    private float DeadLine, toNextScene;

    [SerializeField]
    private string nextScene;

    private float time;
    public VideoPlayer backVideo;

    void Start()
    {
        time = 0.0f;
    }
    void Update()
    {
        time += Time.deltaTime;
        if(backVideo.time > DeadLine + toNextScene)
        {
            SceneManager.LoadScene(nextScene);
        }
        else if(backVideo.time > DeadLine)
        {
            this.gameObject.GetComponent<Image>().enabled = true;
        }
    }
}
