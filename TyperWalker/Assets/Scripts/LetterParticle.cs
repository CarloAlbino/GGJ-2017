using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterParticle : MonoBehaviour {

    public float m_speed = 1.0f;
    public Text m_letterText = null;
    private Vector2 m_randomDir = Vector2.zero;
    private Rigidbody2D m_rb = null;
    private bool m_destroyAfterTime = true;
    [SerializeField]
    private float m_destructionTime = 1.2f;
    private string m_letter = "";
    
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_randomDir.x = Random.Range(-0.8f, 0.8f);
        m_randomDir.y = Random.Range(-0.8f, 0.8f);
        m_rb.AddForce(Vector2.up + m_randomDir * m_speed, ForceMode2D.Impulse);
        StartCoroutine(DestroyAfterTime());
    }

    void Update()
    {
        //transform.Translate((Vector2.up + m_randomDir) * m_speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        WordZone wz = other.GetComponent<WordZone>();
        if(wz != null)
        {
            wz.CheckForWord(this);
        }
    }

    public void SetLetter(string letter)
    {
        m_letterText.text = letter;
        m_letter = letter;
    }

    public void StopDestruction()
    {
        m_destroyAfterTime = false;
    }

    public string GetLetter()
    {
        return m_letter;
    }

    public void SetLayer(LayerMask layer)
    {
        this.gameObject.layer = layer;
    }

    public void SetColour(Color c)
    {
        m_letterText.color = c;
    }

    private IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(m_destructionTime);
        if (m_destroyAfterTime)
        {
            Destroy(this.gameObject);
        }
    }
}
