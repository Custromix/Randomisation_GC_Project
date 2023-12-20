using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rb2d;
    
    [SerializeField]
    private float speed;
    
    [SerializeField]
    private CameraController cameraController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculer la direction de déplacement
        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        movement.Normalize(); // Normaliser pour s'assurer que la vitesse diagonale n'est pas plus rapide

        // Déplacer le personnage
        _rb2d.velocity = movement * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RoomTrigger"))
        {
            cameraController.OnEnterRoomTrigger(other.transform);
        }
    }
}
