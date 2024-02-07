using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    [SerializeField]
    private List<Room> rooms = new List<Room>();
    
    [SerializeField]
    private int _seed;

    public Randomisation _randomisation;

    private static GameManager _thisGameManager;

    [SerializeField]
    private TMP_Text _textMeshProSeed;

    [SerializeField]
    private Room _currentRoom;

    [SerializeField]
    private TextMeshPro _textMeshProPasBon;

    public Room CurrentRoom
    {
        get => _currentRoom;
        set => _currentRoom = value;
    }
    
    [SerializeField]
    private CameraController _cameraController;
    public CameraController CameraController
    {
        get => _cameraController;
    }

    void Start()
    {
        int i = 0;
        Pause();
    }

    // Start is called before the first frame update
    public void InitGameManager(int seed)
    {
        int counter = 0;
        _randomisation = new Randomisation(seed);
        _seed = _randomisation.getSeed();
        Debug.Log(_randomisation.getSeed());
        _randomisation.setRooms(rooms);
        _randomisation.randomChest();
        _randomisation.randomDoors();
        Debug.Log("Is Solvable ? " + numberOfPathSolvable());
        if (numberOfPathSolvable() < 1)
        {
            ReloadGame();
        }
        /*while (1)
        {
            counter++;
            Debug.Log("Compteur " + counter);
            _randomisation.randomDoors();
        }*/
        _textMeshProSeed.text = "Seed : " + _seed;
        _thisGameManager = this;
    }

    public static GameManager getGameManager()
    {
        return _thisGameManager;
    }
    
    public int numberOfPathSolvable()
    {
        int numberOfExitsFound = 0;
        
        Queue<Room> queue = new Queue<Room>();
        HashSet<Room> visited = new HashSet<Room>();

        Room startRoom = GetRoomAt(1, 0);

        queue.Enqueue(startRoom);
        visited.Add(startRoom);

        while (queue.Count > 0)
        {
            Room currentRoom = queue.Dequeue();

            if (IsDestinationRoom(currentRoom))
            {
                numberOfExitsFound++;
            }

            foreach (Door door in currentRoom.getDoors())
            {
                if (door.getIsOpenable())
                {
                    Room nextRoom = GetNextRoom(currentRoom, door);

                    if (nextRoom != null && !visited.Contains(nextRoom))
                    {
                        queue.Enqueue(nextRoom);
                        visited.Add(nextRoom);
                        //door.GetComponent<SpriteRenderer>().color = Color.green;
                    }
                }
            }
        }

        return numberOfExitsFound; // Vérifie si le nombre de sorties trouvé est celui souhaité
        
    }

    // Méthode pour obtenir la salle à la position spécifiée
    private Room GetRoomAt(int x, int y)
    {
        // Implémentez la logique pour obtenir la salle à la position spécifiée
        foreach (Room room in rooms)
        {
            if (room.x == x && room.y == y)
                return room;
        }
        return null;
    }

    // Méthode pour vérifier si la salle est la destination (2:3)
    private bool IsDestinationRoom(Room room)
    {
        // Implémentez la logique pour vérifier si la salle est la destination
        if (room.x == 1 && room.y == 2)
            return true;
        return false;
    }

    // Méthode pour obtenir la salle suivante à travers la porte spécifiée
    public Room GetNextRoom(Room currentRoom, Door door)
    {
        // Implémentez la logique pour obtenir la salle suivante à travers la porte spécifiée
        foreach (Room room in rooms)
        {
            foreach (Door potentialDoor in room.getDoors())
            {
                if (potentialDoor == door)
                {
                    if (room != currentRoom)
                        return room;
                }
            }
        }
        return null;
    }

    public void Pause()
    {
        Time.timeScale = 0.0f;
    }

    public void Continue()
    {
        Time.timeScale = 1.0f;
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
