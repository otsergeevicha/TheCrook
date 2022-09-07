using System;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class Door : MonoBehaviour
{
    public event Action Opened;
    public event Action Closed;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            Opened?.Invoke();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            Closed?.Invoke();
        }
    }

    public void Open()
    {
        transform.position = new Vector3(.85f, 3.5f, transform.position.z);
    }

    public void Close()
    {
        transform.position = new Vector3(0.85f,1.5f, transform.position.z);
    }
}
