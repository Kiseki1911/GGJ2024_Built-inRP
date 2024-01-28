using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GoalUI : MonoBehaviour
{
    public Goal goal;
    public float progressMaxWidth = 600f;
    Image progressImage;
    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<Text>().text = goal.description;
        progressImage = transform.Find("ProgressPanel").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        progressImage.rectTransform.sizeDelta = new Vector2(progressMaxWidth * Mathf.Clamp01(goal.progress), 15f);
        if (goal.fulfilled)
            Destroy(gameObject, 3f);
    }
}
