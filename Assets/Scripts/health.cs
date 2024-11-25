using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{

    public int Health;
    public Transform respawn;
    private bool died;
    public GameObject player;
    void Start()
    {
        died = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            died = true;
            Respawn();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            Health--;
        }
    }

    private void Respawn()
    {
        if (died == true)
        {
            gameObject.transform.position = respawn.transform.position;
        }
        Health = 20;
        died = false;
    }
}
