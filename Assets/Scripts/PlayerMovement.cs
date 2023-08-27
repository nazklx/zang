using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 2f;
    private Rigidbody2D rb;
    private Collider2D cd;
    float shipBoundaryRadius = 0.3f;
    private Vector2 movementDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cd = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        // Move ship around
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
        
        // Screen boundaries
        Vector3 pos = transform.position;
        if(pos.y+shipBoundaryRadius > Camera.main.orthographicSize) {
			pos.y = Camera.main.orthographicSize - shipBoundaryRadius;
		}
		if(pos.y-shipBoundaryRadius < -Camera.main.orthographicSize) {
			pos.y = -Camera.main.orthographicSize + shipBoundaryRadius;
		}

		float screenRatio = (float)Screen.width / (float)Screen.height;
		float widthOrtho = Camera.main.orthographicSize * screenRatio;

		if(pos.x+shipBoundaryRadius > widthOrtho) {
			pos.x = widthOrtho - shipBoundaryRadius;
		}
		if(pos.x-shipBoundaryRadius < -widthOrtho) {
			pos.x = -widthOrtho + shipBoundaryRadius;
		}
		transform.position = pos;

    }

    void FixedUpdate() {
        rb.velocity = movementDirection * movementSpeed;
    }
}
