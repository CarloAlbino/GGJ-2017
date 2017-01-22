using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    [SerializeField, Tooltip("Jump strength")]
    private float m_jumpPower = 10.0f;
    [SerializeField, Tooltip("Walk speed")]
    private float m_walkSpeed = 1.0f;

    // Rigidbody reference
    private Rigidbody2D m_rb = null;
    // Parallax reference
    private FreeParallax m_parallax = null;
    // Reference to the spawn keys object (Player)
    private SpawnKeys m_keys = null;
    // Movement direction
    private Vector2 m_moveDirection = Vector2.zero;
    // Is the player grounded
    private bool m_isGrounded = false;

	void Start ()
    {
        // Grab the references
        m_rb = GetComponent<Rigidbody2D>();
        m_keys = GetComponent<SpawnKeys>();
        m_parallax = FindObjectOfType<FreeParallax>();
	}

	void Update ()
    {
        Movement();
        Debug.Log(m_isGrounded);
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        // Set player to grounded when hit the floor
        if(col.collider.tag == "Floor")
        {
            m_isGrounded = true;
        }
    }

    /// <summary>
    /// Calculate and set the player movement
    /// </summary>
    private void Movement()
    {
        m_moveDirection = Vector2.zero;
        m_moveDirection.y = m_rb.velocity.y;

        if (m_keys.IsRightPressed())
        {
            m_moveDirection += Vector2.right * m_walkSpeed;
        }

        if(m_keys.IsLeftPressed())
        {
            m_moveDirection += Vector2.left * m_walkSpeed;
        }

        // Set the parallax speed
        if(m_keys.IsRightPressed() && m_keys.IsLeftPressed())
        {
            m_parallax.Speed = 0;
        }
        else if(m_keys.IsRightPressed())
        {
            m_parallax.Speed = -1;
        }
        else if(m_keys.IsLeftPressed())
        {
            m_parallax.Speed = 1;
        }
        else
        {
            m_parallax.Speed = 0;
        }

        if (m_isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_moveDirection += Vector2.up * m_jumpPower;
                m_isGrounded = false;
            }
        }
        m_rb.velocity = m_moveDirection;
    }
}
