using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour
{
    public GameObject camObject;

    public float vel = 3f;

    //invaterAnimation用的
    public Animator invaderAnim;
    private float LeftRight;
    private float ForwardBack;
    private bool Jump;
    private bool LftSwoosh;
    private bool RhtSwoosh;

    

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

        //33写的invader的状态机
        LeftRight = Input.GetAxisRaw("Horizontal");
        ForwardBack = Input.GetAxisRaw("Vertical");
        CheckMoveCtrls();
    }

    void FixedUpdate()
    {
        //check move controls and apply speed accordingly
        //CheckMoveCtrls();

        //update animator parameters
        invaderAnim.SetFloat("ForwardBack", ForwardBack);
        invaderAnim.SetFloat("LeftRight", LeftRight);
        invaderAnim.SetBool("Jump", Jump);
        invaderAnim.SetBool("LftSwoosh", LftSwoosh);
        invaderAnim.SetBool("RhtSwoosh", RhtSwoosh);
    }
    

    void CheckMoveCtrls()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump = true;
            invaderAnim.SetTrigger("Jump 0");
            Debug.Log("N");
        }
        else
        {
            Jump = false;
        }

        if ((Input.GetKey(KeyCode.A)) && (Input.GetKey(KeyCode.LeftShift)))
        {
            LftSwoosh = true;
        }
        else
        {
            LftSwoosh = false;
        }

        if ((Input.GetKey(KeyCode.D)) && (Input.GetKey(KeyCode.LeftShift)))
        {
            RhtSwoosh = true;
        }
        else
        {
            RhtSwoosh = false;
        }
    }

    


}
