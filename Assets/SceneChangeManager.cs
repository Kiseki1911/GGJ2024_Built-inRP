using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : Singleton<SceneChangeManager>
{
    private enum SceneState
    {
        StartScene,
        GameSpeechScene,
        ReplayVideoScene,
        VictoryScene
    }

    private SceneState currentSceneState;
    public bool switchScene; // Declare the switchScene variable

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        currentSceneState = SceneState.StartScene; // Set initial state
    }

    // Update is called once per frame
    void Update()
    {
        if (switchScene)
        {
            switchScene = false; // Reset the switch flag
            ChangeScene();
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
                SceneManager.LoadScene("ReplayVideoScene", LoadSceneMode.Single);
                currentSceneState = SceneState.ReplayVideoScene;
                break;
            case SceneState.VictoryScene:
                SceneManager.LoadScene("StartAnimation", LoadSceneMode.Single);
                currentSceneState = SceneState.VictoryScene;
                break;
            default:
                Debug.LogError("Unknown Scene State");
                break;
        }
    }
}
