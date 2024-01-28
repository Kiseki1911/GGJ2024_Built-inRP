using UnityEngine;

public class startAnimationEnd : MonoBehaviour
{
    // This method will be called by the animation event
    public void TriggerSceneChange()
    {
        // Access the SceneChangeManager instance and set its switchScene variable
        SceneChangeManager.Instance.switchScene = true;
    }
}