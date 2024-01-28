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
        videoPlayer.clip = (VideoClip)Resources.Load("Videos/SampleRecordings");
        StartCoroutine(PlayVideo());
    }
    IEnumerator PlayVideo(){
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
        text.enabled = videoPlayer.isPlaying;
        if(Input.GetKeyDown(KeyCode.Space)){

            SceneChangeManager.Instance.switchScene = true;
        }
    }
}
