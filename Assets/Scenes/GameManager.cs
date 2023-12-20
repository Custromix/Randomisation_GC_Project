using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject _chest;
    public Room _room;
    public Randomisation _randomisation;

    // Start is called before the first frame update
    void Start()
    {
        //InitGame();
        //loadChest();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //Debug.Log(_randomisation.getNumberRand());
        }
    }

    
}
