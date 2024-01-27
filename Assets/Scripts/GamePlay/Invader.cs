using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour
{
    public GameObject camObject;

    public float vel = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(camObject.transform);

        //Move
        Vector2 rawMoveVec = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (rawMoveVec.magnitude >= 1f)
            rawMoveVec.Normalize();
        Vector3 radVec = (transform.position - camObject.transform.position);
        radVec.y = 0f;
        if (radVec.sqrMagnitude < 1f)
            rawMoveVec.y = Mathf.Max(rawMoveVec.y, 0f);
        radVec.Normalize();
        Vector3 tanVec = new Vector3(radVec.z, 0f, -radVec.x);
        Vector3 moveVec = rawMoveVec.x * tanVec + rawMoveVec.y * radVec;
        transform.position += moveVec * vel * Time.deltaTime;


    }
}
