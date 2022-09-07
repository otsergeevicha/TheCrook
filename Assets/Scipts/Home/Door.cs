using System;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class Door : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            transform.position = new Vector3(.85f, 3.5f, transform.position.z);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            transform.position = new Vector3(0.85f,1.5f, transform.position.z);
        }
    }
}
