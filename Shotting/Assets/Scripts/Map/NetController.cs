using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetController : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
