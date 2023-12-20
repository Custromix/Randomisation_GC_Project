using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    private bool _isOpen;

    private bool _isOpenable;
    /*private Room currentRoom;
    private Room oldRoom;*/



    
    public void OpenDoor()
    {

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
    /*// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
