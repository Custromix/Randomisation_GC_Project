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
        //return randGenerator.Next(1,4);
        return randGenerator.Next(0,9);
    }
    
    public void randomDoors()
    {
        foreach (Room room in rooms)
        {
            int idOfOpenableDoor;

            bool find;

            int numberDoor = room.getDefClosedDoors().Count;
            int howManyDoorsOpenable = randGenerator.Next(1, (numberDoor+1));

           
            for (int i = 0; i < howManyDoorsOpenable; i++)
            {
                find = false;
                while (!find)
                {
                    idOfOpenableDoor = randGenerator.Next(1, (numberDoor + 1));

                    if (!room.getDoors()[idOfOpenableDoor].getIsOpenable())
                    {
                        room.getDoors()[idOfOpenableDoor].setIsOpenable(true);
                        find = true;
                    }
                }
            }
        }
    }

    public void randomChest()
    {
        int randId;
        foreach (Room room in rooms) 
        {
            randId = randGenerator.Next(9);
            room.getChests()[randId].setIsButtonInThere(true);
        }
    }
}
