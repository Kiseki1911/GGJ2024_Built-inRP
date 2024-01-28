using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviornmentFaceCam : MonoBehaviour
{
    public GameObject camObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(camObject.transform);
    }
}
