using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class SceneChangeManager : Singleton<SceneChangeManager>
{

    private double lastInterval;
    private int frames;
    private float fps;
    public int winner;

    private enum SceneState
    {
        StartScene,
        GameSpeechScene,
        ReplayVideoScene,
        VictoryScene
    }


    private SceneState currentSceneState;
    public bool switchScene; // Declare the switchScene variable
    private float secondsPlayed;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        currentSceneState = SceneState.StartScene; // Set initial state
        lastInterval = Time.realtimeSinceStartup;
        frames = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I)){
            switchScene = true;
        }
        if (switchScene)
        {
            switchScene = false; // Reset the switch flag
            ChangeScene();
        }

        // Increment timer each frame
        secondsPlayed += Time.deltaTime;

        // Check if the current scene is StartScene and 5 seconds have passed
        if (currentSceneState == SceneState.StartScene && secondsPlayed >= 30.0f)
        {
            // Change to the GameSpeechScene
            ChangeScene();
            secondsPlayed = 0; // Reset the timer
        }

    }

    private void ChangeScene()
    {
        switch (currentSceneState)
        {
            case SceneState.StartScene:
                SceneManager.LoadScene("GameSpeechScene", LoadSceneMode.Single);
                currentSceneState = SceneState.GameSpeechScene;
                break;
            case SceneState.GameSpeechScene:
                SceneManager.LoadScene("ReplayVideoScene", LoadSceneMode.Single);
                currentSceneState = SceneState.ReplayVideoScene;
                break;
            case SceneState.ReplayVideoScene:
                SceneManager.LoadScene("VictoryScene", LoadSceneMode.Single);
                currentSceneState = SceneState.VictoryScene;
                break;
            case SceneState.VictoryScene:
                SceneManager.LoadScene("StartScene", LoadSceneMode.Single);
                currentSceneState = SceneState.StartScene;
                break;
            default:
                Debug.LogError("Unknown Scene State");
                break;
        }
    }
}
