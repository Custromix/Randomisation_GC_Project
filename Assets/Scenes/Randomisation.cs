using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Randomisation : MonoBehaviour
{
    [SerializeField]
    private List<Room> rooms = new List<Room>();

    [SerializeField]
    private int _seed;

    private System.Random randGenerator;

    // Start is called before the first frame update
    void Start()
    {
        randGenerator = new System.Random(_seed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void randomChest()
    {
        foreach (Room room in rooms) 
        {
            for (int i = 0; i < room.getChests().Count; i++)
            {
                if (room.getChests()[i].Equals)
                room.getChests()[i]
            }
        }
    }
}
