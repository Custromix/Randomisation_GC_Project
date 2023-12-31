using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Randomisation
{
    private List<Room> _rooms = new List<Room>();

    private int _seed;

    private System.Random randGenerator;

    // Start is called before the first frame update
    public Randomisation(int seed)
    {
        if (seed == 0)
            _seed = (int) System.DateTime.Now.Ticks;
        else
            _seed = seed;
        
        randGenerator = new System.Random(_seed);
    }

    public int getSeed()
    {
        return _seed;
    }
    
    public void setRooms(List<Room> rooms)
    {
        _rooms = rooms;
    }
    
    public void randomDoors()
    {
        foreach (Room room in _rooms)
        {
            int idOfOpenableDoor;

            bool find;

            int numberDoor = room.getDefClosedDoors().Count;
            
            if (numberDoor > 0)
            {
                int howManyDoorsOpenable = randGenerator.Next(1, (numberDoor+1));

                for (int i = 0; i < howManyDoorsOpenable-1; i++)
                {
                    find = false;
                    while (!find)
                    {
                        idOfOpenableDoor = randGenerator.Next(0, room.getDoors().Count);

                        if (!room.getDoors()[idOfOpenableDoor].getIsOpenable())
                        {
                            room.getDoors()[idOfOpenableDoor].setIsOpenable(true);
                            find = true;
                        }
                    }
                }   
            }
        }
    }

    public void randomChest()
    {
        int randId;
        foreach (Room room in _rooms) 
        {
            randId = randGenerator.Next(9);
            room.getChests()[randId].setIsButtonInThere(true);
            if (room.isEnd)
            {
                room.getChests()[randId]._isTheEndChest = true;
            }
        }
    }
}
