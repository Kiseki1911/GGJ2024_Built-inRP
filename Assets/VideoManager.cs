using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public float delayInSec;
    public RawImage img;
    public VideoPlayer videoPlayer;
    public AudioSource source;


    // Start is called before the first frame update
    void Start()
    {
        //source.clip
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
        videoPlayer.Play();
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
