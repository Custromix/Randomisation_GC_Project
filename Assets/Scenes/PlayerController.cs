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

    [SerializeField]
    private Animator _animator;

    private SpriteRenderer _spriteRenderer;

    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float verticalInput = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        //Debug.Log("Hor + Vert " + horizontalInput + " " + verticalInput);
        if(horizontalInput < 0) {
            _spriteRenderer.flipX = true;
        }else if(horizontalInput > 1)
        {
            _spriteRenderer.flipX = false;
        }
        
        _animator.SetFloat("Speed", Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));

        Vector3 movement = new Vector2(horizontalInput, verticalInput);
        //movement.Normalize(); // Normaliser pour s'assurer que la vitesse diagonale n'est pas plus rapide

        _rb2d.velocity = Vector3.SmoothDamp(_rb2d.velocity, movement, ref velocity, .05f);
        //Debug.Log("Velocity " + _rb2d.velocity);



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
