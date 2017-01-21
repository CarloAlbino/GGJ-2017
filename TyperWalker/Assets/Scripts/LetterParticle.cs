using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterParticle : MonoBehaviour {

    public float m_speed = 1.0f;
    public Text m_letter = null;
    private Vector2 m_randomDir = Vector2.zero;
    private Rigidbody2D m_rb = null;
    
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_randomDir.x = Random.Range(-0.8f, 0.8f);
        m_randomDir.y = Random.Range(-0.8f, 0.8f);
        m_rb.AddForce(Vector2.up + m_randomDir * m_speed, ForceMode2D.Impulse);
        Destroy(this.gameObject, 1.2f);
    }

    void Update()
    {
        //transform.Translate((Vector2.up + m_randomDir) * m_speed * Time.deltaTime);
    }

    public void SetLetter(string letter)
    {
        m_letter.text = letter;
    }
}
