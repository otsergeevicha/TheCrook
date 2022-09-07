using UnityEngine;

public class Home : MonoBehaviour
{
    [SerializeField] private Door _door;


    private void OnEnable()
    {
        _door.Opened += OpenDoor;
        _door.Closed += CloseDoor;
    }

    private void OnDisable()
    {
        _door.Opened -= OpenDoor;
        _door.Closed -= CloseDoor;
    }

    private void OpenDoor()
    {
        _door.Open();
    }

    private void CloseDoor()
    {
        _door.Close();
    }
}
