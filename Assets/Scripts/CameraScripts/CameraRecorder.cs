using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityMediaRecorder.Utils;
using UnityMediaRecorder;
[RequireComponent((typeof(Camera)))]
public class CameraRecorder : MonoBehaviour
{
    public RecorderBehaviour recorder_;
    public Camera cam;
    bool isRecording;
    // Start is called before the first frame update
    void Start()
    {
        //recorder_ = this.GetComponent<RecorderBehaviour>();
        //cam = GetComponent<Camera>();
        isRecording = false;
        StartRecording();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnDisable()
    {
        StopRecording();
    }

    public void StartRecording()
    {
        cam = GameObject.Find("CameraMan_Cam").GetComponent<Camera>();
        //if (recorder_.State == RecorderState.IDLE) {
        VideoParams vParams = new VideoParams(30, 4000000, cam.pixelWidth, cam.pixelHeight, "vflip");
        AudioParams aParams = new AudioParams(AudioSettings.outputSampleRate, 320000, string.Empty, AudioSettings.speakerMode);
        string filename = //Path.Combine("Assets/Resources/Videos/SampleRecordings");
        Path.Combine(
          Environment.GetFolderPath(Environment.SpecialFolder.MyVideos),
          "GGJ2024_cq");//DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString());
        RecordingOptions recOpts = new RecordingOptions(filename, vParams, aParams);
        recorder_.StartRecording(recOpts).HandleAsyncExceptions();
        isRecording = true;
        //} 
    }
    public void StopRecording()
    {
        //if (recorder_.State == RecorderState.RECORDING) {
        recorder_.StopRecording().HandleAsyncExceptions();
        isRecording = false;
        //}
    }
}
