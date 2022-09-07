using System;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _rigidbody.AddForce(_speed * Time.deltaTime, 0, 0, ForceMode.Impulse);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            _rigidbody.AddForce(0, 0, _speed * Time.deltaTime, ForceMode.Impulse);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            _rigidbody.AddForce(0, 0, -_speed * Time.deltaTime, ForceMode.Impulse);
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            _rigidbody.AddForce(-_speed * Time.deltaTime, 0, 0, ForceMode.Impulse);
        }
    }
}
