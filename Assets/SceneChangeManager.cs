using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : Singleton<SceneChangeManager>
{
    public bool switchScene = false;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (switchScene)
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("StartScene"))
            {
                SceneManager.LoadScene("GameplayTestScene",LoadSceneMode.Single);
                //SceneManager.UnloadSceneAsync(0);
            }
            else{
                SceneManager.LoadScene("StartScene",LoadSceneMode.Single);
                //SceneManager.UnloadSceneAsync(1);

            }
            switchScene = false;
        }
    }
}
