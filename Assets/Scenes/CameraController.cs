using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform[] roomPositions;

    private int _currentRoomIndex = 0;

    void Start()
    {
        if (roomPositions.Length > 0)
        {
            SetCameraToCurrentRoom();
        }
    }

    public void OnEnterRoomTrigger(Transform roomTrigger)
    {
        int roomTriggerIndex = System.Array.IndexOf(roomPositions, roomTrigger);

        if (roomTriggerIndex != -1)
        {
            _currentRoomIndex = roomTriggerIndex;
            SetCameraToCurrentRoom();
        }
    }

    void SetCameraToCurrentRoom()
    {
        if (_currentRoomIndex >= 0 && _currentRoomIndex < roomPositions.Length)
        {
            transform.position = new Vector3(roomPositions[_currentRoomIndex].position.x, roomPositions[_currentRoomIndex].position.y, transform.position.z);
        }
    }
}
