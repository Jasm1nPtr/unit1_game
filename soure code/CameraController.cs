using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    private Vector3 offset;
    void Start()
    {
        offset = transform.position - player.position;
    }


    void LateUpdate() 
    {
        Vector3 newPosisi = new Vector3(transform.position.x, transform.position.y, offset.z + player.position.z);
        transform.position = Vector3.Lerp(transform.position, newPosisi, 15);
    }
}
