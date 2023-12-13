using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : ScriptableObject
{

    private int _id;

    private bool _isButtonInThere;



    public bool getIsButtonInThere()
    {
        return _isButtonInThere;
    }

    public void setIsButtonInThere(bool isButton)
    {
        _isButtonInThere = isButton;
    }


}
