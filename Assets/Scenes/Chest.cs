using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Chest", menuName = "My Game/Chest")]
public class Chest : MonoBehaviour
{

    private int _id;

    private bool _isButtonInThere;

    private void Awake()
    {
        _isButtonInThere = false;
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


}
