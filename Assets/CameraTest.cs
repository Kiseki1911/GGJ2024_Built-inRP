using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityMediaRecorder.Utils;
using UnityMediaRecorder;
[RequireComponent(typeof(RecorderBehaviour))]
public class CameraTest : MonoBehaviour
{
    private RecorderBehaviour recorder_;
    // Start is called before the first frame update
    void Start()
    {
        recorder_ = this.GetOrAddComponent<RecorderBehaviour>();

    }

    // Update is called once per frame
    void Update()
    {
        VideoParams vParams = new VideoParams(30, 4000000, 512, 512, "vflip");
        AudioParams aParams = new AudioParams(AudioSettings.outputSampleRate, 320000, string.Empty, AudioSettings.speakerMode);
        string filename = Path.Combine(Application.dataPath, "..", "SampleRecordings");
        // Path.Combine(
        //   Environment.GetFolderPath(Environment.SpecialFolder.MyVideos),
        //   DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString());
        RecordingOptions recOpts = new RecordingOptions(filename, vParams, aParams);
        recorder_.StartRecording(recOpts).HandleAsyncExceptions();


        float sine = Mathf.Sin(0.5f * Mathf.PI * Time.time);
        transform.position = new Vector3(5f * sine, 0f, 0f);
        transform.rotation = Quaternion.Euler(20f * sine, 0f, 0f);
    }
    private void OnDisable()
    {
        recorder_.StopRecording().HandleAsyncExceptions();
    }
}
