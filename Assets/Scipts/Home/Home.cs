using System;
using UnityEngine;

public class Home : MonoBehaviour
{
    public event Action Penetration;
    public event Action Leaving;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            Penetration?.Invoke();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            Leaving?.Invoke();
        }
    }
}
