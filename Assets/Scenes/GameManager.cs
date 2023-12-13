using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject _chest;
    public Room _room;
    public Sprite _sprite;
    public Vector3 _position;

    // Start is called before the first frame update
    void Start()
    {
        //InitGame();
        loadChest();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadChest()
    {
        for (int i = 0; i < 4; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                GameObject chestObject = Instantiate(_chest);
                Vector3 newPos = new Vector3(_position.x + (10 * j), _position.y - (3 * i), _position.z);
                chestObject.transform.SetPositionAndRotation(newPos, chestObject.transform.rotation);
            }
        }

    }
}
