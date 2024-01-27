using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderCam : MonoBehaviour
{
    public GameObject invaderObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(invaderObject.transform);
    }
}
