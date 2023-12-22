using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Chest", menuName = "My Game/Chest")]
public class Chest : MonoBehaviour
{
    private static int countChest = 0;

    private int _id;

    private bool _isButtonInThere = false;

    private Room _room;

    private void Awake()
    {
        _id = countChest;
        if(countChest == 8)
            countChest = 0;
        else 
            countChest++;
    }

    public int getId()
    {
        return _id;
    }

    public bool getIsButtonInThere()
    {
        return _isButtonInThere;
    }

    public void setIsButtonInThere(bool isButton)
    {
        _isButtonInThere = isButton;
    }

    public void setRoom(Room room)
    {
        _room = room;
    }

    void Update()
    {
        //Test random
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 rayPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(rayPosition, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject == gameObject)
                {
                    Debug.Log("Le coffre est " + getIsButtonInThere());
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Le coffre est " + getIsButtonInThere());
                if (getIsButtonInThere())
                {
                    transform.parent.gameObject.GetComponent<Room>().OpenDoors();
                }
            }
        }
    }
}
