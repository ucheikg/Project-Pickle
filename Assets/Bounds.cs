using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    public Transform player;
    public float x, y, z;
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag== "player")
        {
            player.position = new Vector3(x, y, z);
        }
    }
}
