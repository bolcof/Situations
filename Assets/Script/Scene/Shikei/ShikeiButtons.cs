using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ShikeiButtons : MonoBehaviour
{
    private VideoLoader Vloader;
    private VideoPlayer Vplayer;
    private GameObject afterButtonVideo;

    private float leftTime, rightTime, afterButtonTime;
    public bool[] switched = new bool[3];
    public bool isHunged;

    public SpriteRenderer[] switchObj = new SpriteRenderer[3];
    public Sprite[] switchOnImg = new Sprite[3];

    void Start() {
        Vloader = this.gameObject.GetComponent<VideoLoader>();
        Vplayer = this.gameObject.GetComponent<VideoPlayer>();
        afterButtonVideo = GameObject.Find("afterButtonVideo");

        Vplayer.time = afterButtonTime = 0.0f;
        leftTime = Random.Range(12.5f, 19.0f);
        rightTime = Random.Range(12.5f, 19.0f);

        switched[0] = switched[1] = switched[2] = false;
        isHunged = false;
    }

    void Update() {
        Debug.Log(Vplayer.time);
        if(Vplayer.time >= leftTime)
        {
            switched[0] = true;
            switchObj[0].sprite = switchOnImg[0];

        }
        if(Vplayer.time >= rightTime)
        {
            switched[2] = true;
            switchObj[2].sprite = switchOnImg[2];
        }

        if (switched[0] && switched[1] && switched[2] && !isHunged) {
            pushAllButton();
        }

        if (isHunged) {
            afterButtonTime += Time.deltaTime;
            if(afterButtonTime >= 7.5f)
            {
                GameObject.Find("BlackFade").GetComponent<BlackFade>().isFadingOn = true;
            }
        }
    }

    public void pushMiddle() {
        switched[1] = true;
        switchObj[1].sprite = switchOnImg[1];
    }

    void pushAllButton() {
        afterButtonVideo.SetActive(true);
        afterButtonVideo.GetComponent<VideoPlayer>().Play();
        afterButtonVideo.GetComponent<VideoPlayer>().isLooping = false;
        isHunged = true;
    }
}
