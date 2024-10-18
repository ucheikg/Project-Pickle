using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class playe_movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        while (Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        while (Input.GetKeyDown(KeyCode.S))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime); 
        }
    }
}
