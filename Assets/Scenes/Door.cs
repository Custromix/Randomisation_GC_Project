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

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OpenDoor()
    {
        if (_isOpenable)
        {
            _col2d.isTrigger = true;
            _spriteRenderer.sprite = _doorOpenSprite;
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
        GameManager.getGameManager().CurrentRoom = GameManager.getGameManager().GetNextRoom(GameManager.getGameManager().CurrentRoom,this);
        GameManager.getGameManager().CameraController.OnEnterRoomTrigger(GameManager.getGameManager().CurrentRoom.transform);
    }
}
