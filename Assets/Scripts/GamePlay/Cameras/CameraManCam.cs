using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManCam : MonoBehaviour
{
    public float sensiX = 12f;
    public float sensiY = 6f;
    public float basicFoV = 50f;
    public float zoom = 1f;
    Camera cam;
    GameObject glitchImage;
    public float leftClickDownTime = 0f;
    public float zoomInStartTime = 1f;
    public float zoomInRatio = 0.5f;

    public Vector3 basicRot;
    Vector3 rotation;

    float waitTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        glitchImage = GameObject.Find("GlitchImage");
        glitchImage.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cam = GetComponent<Camera>();
        basicFoV = cam.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        if(waitTime <= 1f)
		{
            waitTime += Time.deltaTime;
            return;
		}
        float moveX = Input.GetAxis("Mouse X") * sensiX * Time.deltaTime;
        float moveY = Input.GetAxis("Mouse Y") * sensiY * Time.deltaTime;
        rotation += new Vector3(moveY, moveX, 0f);
        transform.rotation = Quaternion.Euler(rotation);

        if (Input.GetMouseButton(0))
            leftClickDownTime += Time.deltaTime;
        else
            leftClickDownTime = 0f;


        glitchImage.SetActive(Input.GetMouseButton(1));

        if (leftClickDownTime > zoomInStartTime)
            zoom += zoomInRatio * Time.deltaTime;
        else if (leftClickDownTime <= 0f)
            zoom -= zoomInRatio * Time.deltaTime;
        zoom = Mathf.Clamp(zoom, 1f, 3f);

        cam.fieldOfView = basicFoV / zoom;
    }
}
