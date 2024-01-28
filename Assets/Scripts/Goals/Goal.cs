using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public static int CameraManGoalFulfilled = 0;
    public static int InvaderGoalFulfilled = 0;


    static GameObject GoalUIPrefab;
    public enum GoalType { Interact, Frame};
    public enum GoalOwner { CameraMan, Invader };
    public float progress = 0f;
    public bool fulfilled = false;

    public string description = "";

    [Header("Type")]
    public GoalType goalType = GoalType.Frame;
    public GoalOwner goalOwner = GoalOwner.Invader;

    [Header("Frame")]
    // if true, need targetObj in frame. if false, need targetObj outside frame.
    public bool needInFrame = true; 
    public GameObject targetObj;
    GameObject invaderObj;
    Animator invaderAnim;
    public bool needInvaderIn = false;
    public List<string> needInvaderState;

    public float startTime = 5f;
    bool started = false;
    public float timeNeeded = 1f;
    float curTime = 0f;
    public float minZoom = 1f;



    [Header("Interact (tutorial)")]
    public string[] axis;


    Camera cam;
    CameraManCam cmc;
    Plane[] cameraFrustum;
    Bounds bounds;
    // Start is called before the first frame update
    void Start()
    {
        if (!GoalUIPrefab)
            GoalUIPrefab = Resources.Load<GameObject>("Prefabs/GoalUI");

        switch (goalType)
        {
            case GoalType.Frame:
                cam = GameObject.Find("CameraMan_Cam").GetComponent<Camera>();
                cmc = FindObjectOfType<CameraManCam>();
                invaderObj = GameObject.Find("Invader");
                invaderAnim = invaderObj.GetComponentInChildren<Animator>();
                break;
            case GoalType.Interact:

                break;
        }
    }

    bool CheckInFrame(GameObject obj)
    {
        if (!obj)
            return true;
        bounds = obj.GetComponent<Collider>().bounds;
        cameraFrustum = GeometryUtility.CalculateFrustumPlanes(cam);
        return GeometryUtility.TestPlanesAABB(cameraFrustum, bounds);
    }

    void OnStarted()
    {
        GameObject parentObj = null;
        switch (goalOwner)
        {
            case GoalOwner.CameraMan:
                parentObj = GameObject.Find("CameraManGoalPanel");
                break;
            case GoalOwner.Invader:
                parentObj = GameObject.Find("InvaderGoalPanel");
                break;
        }
        var goalUIObj = GameObject.Instantiate(GoalUIPrefab, parentObj.transform);
        //goalUIObj.transform.SetAsLastSibling();
        var goalUI = goalUIObj.GetComponent<GoalUI>();
        goalUI.goal = this;

    }
    void OnFulfill()
    {
        switch (goalOwner)
        {
            case GoalOwner.CameraMan:
                CameraManGoalFulfilled++;
                break;
            case GoalOwner.Invader:
                InvaderGoalFulfilled++;
                break;
        }
    }


    bool CheckInvaderState()
	{
        if (needInvaderState.Count == 0)
            return true;
        var c = invaderAnim.GetCurrentAnimatorClipInfo(0);
        if (c.Length <= 0)
            return false;
        string state = c[0].clip.name;
        Debug.Log("State = " + state);
        return needInvaderState.Contains(state);

    }

    // Update is called once per frame
    void Update()
    {
        if(!started)
		{
            if(Time.time >= startTime)
			{
                started = true;
                OnStarted();
			}
            else
                return;
		}


        if(!fulfilled)
        {
            switch (goalType)
            {
                case GoalType.Frame:
                    if ((!targetObj) || CheckInFrame(targetObj) == needInFrame)
                    {
                        if (needInvaderIn && !CheckInFrame(invaderObj))
                            break;

                        if (cmc.zoom < minZoom)
                            break;
                        // need to implement: check invader state(pose)

                        if (!CheckInvaderState())
                            break;

                        progress += Time.deltaTime / timeNeeded;
                    }
                    break;
                case GoalType.Interact:
                    foreach (var a in axis)
                    {
                        if (Mathf.Abs(Input.GetAxis(a)) >= 0.001f)
                        {
                            progress += 1f;
                            break;
                        }
                    }
                    break;
            }

            if (progress >= 1f)
            {
                fulfilled = true;
                OnFulfill();
            }
        }
    }
}
