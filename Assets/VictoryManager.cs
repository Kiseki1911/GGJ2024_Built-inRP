using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VictoryManager : MonoBehaviour
{
    public string cameraManWins, intruderWins, draw;
    public TMP_Text text;
    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        text.text = SceneChangeManager.Instance.winner == 1 ?
            cameraManWins : SceneChangeManager.Instance.winner == -1 ? intruderWins : draw;
    }

    public void Restart(){
        SceneChangeManager.Instance.switchScene = true;
    }
    public void Exit(){
        Application.Quit();
    }
}
