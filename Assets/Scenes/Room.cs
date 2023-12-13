using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : ScriptableObject
{

    private int _id;

    [SerializeField]
    private List<Door> doors;

    [SerializeField]
    private List<Chest> chests;

    private List<Door> _openableDoors;



    public List<Chest> getChests()
    {
        return chests;
    }

    /*
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }*/
}
