using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    private Vector3 rot, dir;
    private Vector3 pos, mouse;
    private float angle;

    void Update()
    {
        //mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log(mouse);
        mouse.y = 0;
        dir = transform.position - mouse;
        angle = Mathf.Atan2(-dir.x, -dir.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
    }
}
