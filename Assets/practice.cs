using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class practice : MonoBehaviour
{
    // Start is called before the first frame update
    public float myYRotation;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, 0.5f, 0, Space.World);
        Debug.Log("my rootation:" + this.transform.localRotation.y);
    }
}
