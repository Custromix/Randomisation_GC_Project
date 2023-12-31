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

    private bool _isPlayerClose = false;

    [SerializeField]
    private Canvas _canvas;

    [SerializeField]
    private Sprite _chestOpenSprite;

    SpriteRenderer _spriteRenderer;

    private bool spriteChanged = false;

    public bool _isTheEndChest = false;



    private void Awake()
    {
        _id = countChest;
        if(countChest == 8)
            countChest = 0;
        else 
            countChest++;

        _spriteRenderer = GetComponent<SpriteRenderer>();

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

        if (_isPlayerClose)
        {
            if (!spriteChanged)
                _canvas.gameObject.SetActive(true);
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Le coffre est " + getIsButtonInThere());

                if (!spriteChanged)
                {
                    _spriteRenderer.sprite = _chestOpenSprite;
                    spriteChanged = true;
                }

                if (getIsButtonInThere())
                {
                    transform.parent.gameObject.GetComponent<Room>().OpenDoors();
                    if(_isTheEndChest) 
                    { 
                        transform.parent.gameObject.GetComponent<Room>()._canvasEnd.gameObject.SetActive(true);
                        transform.parent.gameObject.GetComponent<Room>()._gameManager.Pause();
                    }

                }
            }
        }
        else
            _canvas.gameObject.SetActive(false);



    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _isPlayerClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _isPlayerClose = false;
        }
    }
}
