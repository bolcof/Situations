using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BlackFade : MonoBehaviour
{
    public float fadeTime;
    public string nextScene;
    private float time;
    private bool isFadingOn, isFadingOff;

    private void Start() {
        time = 0.0f;
        isFadingOn = false;
        isFadingOff = true;
    }

    private void Update() {

        if (isFadingOff)
        {
            time += Time.deltaTime;
            float alpha = time / fadeTime;
            this.gameObject.GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, 1.0f - alpha);
        }
        else if (isFadingOn)
        {
            time += Time.deltaTime;
            float alpha = time / fadeTime;
            this.gameObject.GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, alpha);
            if (time >= fadeTime)
            {
                //SceneManager.LoadScene(nextScene);
            }
        }
    }

    void fadeOut(bool isOn) {
        if (!isFadingOff && !isFadingOn) {
            if (isOn) { isFadingOn = true; }
            else if (!isOn) { isFadingOff = true; }
        }
    }
}
