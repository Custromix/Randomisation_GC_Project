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

    public int x;
    
    public int y;

    public bool isEnd = false;

    public Canvas _canvasEnd;

    public GameManager _gameManager;

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
    
        
    public List<Door> getDefClosedDoors()
    {
        List<Door> closedDoors = new List<Door>();

        foreach (Door door in doors)
        {
            if(!door.getIsOpenable())
                closedDoors.Add(door);
        }
        
        return closedDoors;
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
            }
        }
    }

    public void OpenDoors()
    {
        foreach (Door door in doors)
        {
            door.OpenDoor();
        }
    }
}
