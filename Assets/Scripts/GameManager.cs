using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnEnable()
    {
        Goal.CameraManGoalFulfilled = 0;
        Goal.InvaderGoalFulfilled = 0;
        StartCoroutine(GameTimer());
    }
    void End()
    {
        SceneChangeManager.Instance.winner = Goal.CameraManGoalFulfilled - Goal.InvaderGoalFulfilled > 0 ?
            1 : (Goal.CameraManGoalFulfilled - Goal.InvaderGoalFulfilled < 0 ? -1 : 0);

        SceneChangeManager.Instance.switchScene = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator GameTimer()
    {
        yield return new WaitForSeconds(45);
        End();
    }
}
