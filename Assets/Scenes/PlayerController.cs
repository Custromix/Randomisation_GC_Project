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

    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float verticalInput = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        // Calculer la direction de déplacement
        Vector3 movement = new Vector2(horizontalInput, verticalInput);
        //movement.Normalize(); // Normaliser pour s'assurer que la vitesse diagonale n'est pas plus rapide

        _rb2d.velocity = Vector3.SmoothDamp(_rb2d.velocity, movement, ref velocity, .05f);

        // Déplacer le personnage
        //_rb2d.velocity = movement * speed;
    }

    /*void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RoomTrigger"))
        {
            cameraController.OnEnterRoomTrigger(other.transform);
        }
    }*/
}
