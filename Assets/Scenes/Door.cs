using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{

    private bool _isOpen;

    private bool _isOpenable;

    [SerializeField]
    private Collider2D _col2d;

    private SpriteRenderer _spriteRenderer;

    [SerializeField]
    private Sprite _doorOpenSprite;

    [SerializeField]
    private GameManager _gameManager;

    [SerializeField]
    private GameObject _doorSideOpen;

    public bool isSide = false;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OpenDoor()
    {
        if (_isOpenable)
        {
            _col2d.isTrigger = true;

            if (isSide)
            {
                _doorSideOpen.SetActive(true);
                this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                _spriteRenderer.sprite = _doorOpenSprite;
            }
        }
    }

    private void Update()
    {
        if(_isOpenable)
        {
            _spriteRenderer.color = Color.green;
        }
    }

    public bool getIsOpen()
    {
        return _isOpen;
    }
    
    public void setIsOpen(bool isOpen)
    {
        _isOpen = isOpen;
    }
    
    public bool getIsOpenable()
    {
        return _isOpenable;
    }
    
    public void setIsOpenable(bool isOpenable)
    {
        _isOpenable = isOpenable;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        _gameManager.CurrentRoom = _gameManager.GetNextRoom(_gameManager.CurrentRoom,this);
        _gameManager.CameraController.OnEnterRoomTrigger(_gameManager.CurrentRoom.transform);
    }
}
