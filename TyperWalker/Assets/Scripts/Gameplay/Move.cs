using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    [SerializeField, Tooltip("Jump strength")]
    private float m_jumpPower = 10.0f;
    [SerializeField, Tooltip("Walk speed")]
    private float m_walkSpeed = 1.0f;

    // Get references
    private Rigidbody2D m_rb = null;
    private Animator m_animator = null;
    private FreeParallax m_parallax = null;
    private SpriteRenderer m_sprite = null;
    private RandomJumpAudio m_jumpAudio = null;
    // Reference to the spawn keys object (Player)
    private SpawnKeys m_keys = null;
    // Movement direction
    private Vector2 m_moveDirection = Vector2.zero;
    // Is the player grounded
    private bool m_isGrounded = false;
    // is player moving right
    private bool m_isMoveingRight = true;

	void Start ()
    {
        // Grab the references
        m_rb = GetComponent<Rigidbody2D>();
        m_animator = GetComponentInChildren<Animator>();
        m_keys = GetComponent<SpawnKeys>();
        m_parallax = FindObjectOfType<FreeParallax>();
        m_sprite = GetComponentInChildren<SpriteRenderer>();
        m_jumpAudio = GetComponentInChildren<RandomJumpAudio>();
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
            m_isMoveingRight = true;
        }

        if(m_keys.IsLeftPressed())
        {
            m_moveDirection += Vector2.left * m_walkSpeed;
            m_isMoveingRight = false;
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
                m_jumpAudio.JumpSound();
                m_isGrounded = false;
            }
        }
        m_rb.velocity = m_moveDirection;

        // Set the sprite's scale and animation
        if(m_isGrounded)
        {
            m_animator.SetBool("IsJumping", false);
        }
        else
        {
            m_animator.SetBool("IsJumping", true);
        }

        Vector2 tempDir = m_moveDirection;
        tempDir.y = 0;
        if (Mathf.Abs(tempDir.magnitude) > Mathf.Epsilon)
        {
            m_animator.SetBool("IsWalking", true);
        }
        else
        {
            m_animator.SetBool("IsWalking", false);
        }

        if (m_isMoveingRight)
        {
            Vector3 newScale = Vector3.one;
            newScale *= Mathf.Abs(m_sprite.transform.localScale.x);
            m_sprite.transform.localScale = newScale;
        }
        else
        {
            Vector3 newScale = Vector3.one;
            newScale.x *= Mathf.Abs(m_sprite.transform.localScale.x) * -1;
            m_sprite.transform.localScale = newScale;
        }
    }
}
