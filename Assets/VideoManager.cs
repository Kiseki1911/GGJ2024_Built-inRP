using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System;
using System.IO;

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
        yield return new WaitForSeconds(5);
        videoPlayer.url = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "GGJ2024_cq.mp4");//(VideoClip)Resources.Load("Videos/SampleRecordings");
        videoPlayer.Prepare();
        yield return new WaitForSeconds(delayInSec);
        while(!videoPlayer.isPrepared){
            yield return new WaitForSeconds(0.5f);
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
