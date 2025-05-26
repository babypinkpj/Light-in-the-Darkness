using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightFollow : MonoBehaviour
{
     public Transform player;
    public Vector3 offset = new Vector3(0, 2, 0);
    public float followSpeed = 5f;  // ปรับความเร็วการติดตาม

    void LateUpdate()
    {
        if (player != null)
        {
            // ทำให้ไฟตาม Player แบบ Smooth
            transform.position = Vector3.Lerp(transform.position, player.position + offset, followSpeed * Time.deltaTime);
        }
    }
}
