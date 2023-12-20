using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Room : MonoBehaviour
{

    private int _id;

    [SerializeField]
    private List<Door> doors;

    [SerializeField]
    private List<Chest> chests;

    [SerializeField]
    private GameObject chestPrefab;
    
    private List<Door> _openableDoors;

    void Awake()
    {
        loadChest();
    }


    public List<Chest> getChests()
    {
        return chests;
    }

    public List<Door> getDoors()
    {
        return doors;
    }

    public void loadChest()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                GameObject chestObject = Instantiate(chestPrefab);
                chestObject.transform.SetParent(transform);

                Vector3 newPos = new Vector3(-0.3f + (0.3f * j), -0.3f + (0.3f * i), transform.position.z);
                chestObject.transform.localPosition = newPos;

                chests.Add(chestObject.GetComponent<Chest>());
                //Debug.Log(chestObject.GetComponent<Chest>().getId());
            }
        }
        
        

    }
}
