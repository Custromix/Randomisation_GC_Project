using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject _chest;
    private List<Room> rooms;
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


    public bool IsPathSolvable()
    {
        // Algorithme BFS pour vérifier la solvabilité du chemin
        Queue<Room> queue = new Queue<Room>();
        HashSet<Room> visited = new HashSet<Room>();

        // Commencer depuis la salle en 2:1
        Room startRoom = GetRoomAt(2, 1);

        queue.Enqueue(startRoom);
        visited.Add(startRoom);

        while (queue.Count > 0)
        {
            Room currentRoom = queue.Dequeue();

            // Vérifier si la salle actuelle est la destination (2:3)
            if (IsDestinationRoom(currentRoom))
            {
                return true; // Chemin solvable
            }

            foreach (Door door in currentRoom.getDoors())
            {
                // Vérifier si la porte est ouvrable et mène à une salle non visitée
                if (door.getIsOpenable())
                {
                    Room nextRoom = GetNextRoom(currentRoom, door);

                    if (nextRoom != null && !visited.Contains(nextRoom))
                    {
                        queue.Enqueue(nextRoom);
                        visited.Add(nextRoom);
                    }
                }
            }
        }

        return false; // Aucun chemin vers la destination
    }

    // Méthode pour obtenir la salle à la position spécifiée
    private Room GetRoomAt(int row, int column)
    {
        // Implémentez la logique pour obtenir la salle à la position spécifiée
        return null;
    }

    // Méthode pour vérifier si la salle est la destination (2:3)
    private bool IsDestinationRoom(Room room)
    {
        // Implémentez la logique pour vérifier si la salle est la destination
        return false;
    }

    // Méthode pour obtenir la salle suivante à travers la porte spécifiée
    private Room GetNextRoom(Room currentRoom, Door door)
    {
        // Implémentez la logique pour obtenir la salle suivante à travers la porte spécifiée
        return null;
    } 

}
