using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    private Rigidbody2D m_rb = null;
    private SpawnKeys m_keys = null;
    private Vector2 m_moveDirection = Vector2.zero;
    public float m_jumpPower = 10.0f;
    public float m_walkSpeed = 1.0f;
    private bool m_isGrounded = false;

	void Start ()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_keys = GetComponent<SpawnKeys>();
	}

	void Update ()
    {
        Movement();
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "Floor")
        {
            m_isGrounded = true;
        }
    }

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
