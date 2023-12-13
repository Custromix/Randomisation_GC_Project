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
        randomChest();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int getNumberRand()
    {
        return randGenerator.Next(1,4);
    }
    
    public void randomDoors()
    {
        foreach (Room room in rooms)
        {
            int numberDoor = room.getDoors().Count;

            List<int> idChoosen = new List<int>();

            int howManyDoorsOpenable = randGenerator.Next(1, (numberDoor+1));

            int idOfOpenableDoor;


            for (int i = 0; i < howManyDoorsOpenable; i++)
            {

                bool find = false;
                while (!find)
                {
                    idOfOpenableDoor = randGenerator.Next(1, (numberDoor + 1));

                    if (!idChoosen.Contains(idOfOpenableDoor))
                    {
                        idChoosen.Add(idOfOpenableDoor);
                        find = true;
                    }

                }

            }


        }
    }

    public void randomChest()
    {
        foreach (Room room in rooms) 
        {
            int randId = randGenerator.Next(9);
            room.getChests()[randId].setIsButtonInThere(true);
        }
    }
}
