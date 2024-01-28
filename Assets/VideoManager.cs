using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public float delayInSec;
    public RawImage img;
    public VideoPlayer videoPlayer;
    bool videoReady = false;
    public TMP_Text text;


    // Start is called before the first frame update
    void Start()
    {
        videoReady = false;
        StartCoroutine(PlayVideo());
    }
    IEnumerator PlayVideo(){
        yield return new WaitForSeconds(3);
        videoPlayer.clip = (VideoClip)Resources.Load("Videos/SampleRecordings");
        videoPlayer.Prepare();
        yield return new WaitForSeconds(delayInSec);
        while(!videoPlayer.isPrepared){
            yield return new WaitForSeconds(1);
            break;
        }
        img.texture = videoPlayer.texture;
        videoReady = true;
        videoPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = videoPlayer.isPlaying? "Press [BACK SPACE] to skip": "Waiting for video...";
        if(Input.GetKeyDown(KeyCode.Backspace)){

            SceneChangeManager.Instance.switchScene = true;
        }
    }
}
