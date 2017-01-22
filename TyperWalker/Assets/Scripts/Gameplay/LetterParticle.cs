using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterParticle : MonoBehaviour {

    [SerializeField, Tooltip("The particle's speed")]
    private float m_speed = 1.0f;
    [SerializeField, Tooltip("Time before the destruction of the particle")]
    private float m_destructionTime = 1.2f;
    [SerializeField, Tooltip("Reference to the text display")]
    private Text m_letterText = null;

    // Direction to move in
    private Vector2 m_randomDir = Vector2.zero;
    // Should the particle be destroyed
    private bool m_destroyAfterTime = true;
    // The letter the particle will display
    private string m_letter = "";

    // Reference
    private Rigidbody2D m_rb = null;

    void Start()
    {
        // Get Reference to ridgidbody
        m_rb = GetComponent<Rigidbody2D>();
        // Set Random Direction
        m_randomDir.x = Random.Range(-0.8f, 0.8f);
        m_randomDir.y = Random.Range(-0.8f, 0.8f);
        // Add force to the particle
        m_rb.AddForce(Vector2.up + m_randomDir * m_speed, ForceMode2D.Impulse);
        // Start destruction timer
        StartCoroutine(DestroyAfterTime());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check to see if the particle entered a word zone
        WordZone wz = other.GetComponent<WordZone>();
        if(wz != null)
        {
            // is it part of the word
            wz.CheckForWord(this);
        }

        BasePuzzle bp = other.GetComponent<QuietPuzzle>();
        if(bp != null)
        {
            Debug.Log("Done");
            // Activate any special effects
            bp.SpecialEffect(this);
        }
        
    }

    #region Public Functions

    /// <summary>
    /// Set what letter the particle is displaying
    /// </summary>
    /// <param name="letter">New letter for the particle to display</param>
    public void SetLetter(string letter)
    {
        m_letterText.text = letter;
        m_letter = letter;
    }

    /// <summary>
    /// Stop the destruction timer
    /// </summary>
    public void StopDestruction()
    {
        m_destroyAfterTime = false;
    }

    /// <summary>
    /// Get the letter of the particle
    /// </summary>
    /// <returns>The letter that the particle is displaying</returns>
    public string GetLetter()
    {
        return m_letter;
    }

    /// <summary>
    /// Set the physics layer of the particle
    /// </summary>
    /// <param name="layer">Physics layer</param>
    public void SetLayer(LayerMask layer)
    {
        this.gameObject.layer = layer;
    }

    /// <summary>
    /// Set the colour of the text
    /// </summary>
    /// <param name="c">Color to turn to</param>
    public void SetColour(Color c)
    {
        m_letterText.color = c;
    }

    #endregion Public Functions


    #region Private Functions

    /// <summary>
    /// Destruction timer
    /// </summary>
    private IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(m_destructionTime);
        if (m_destroyAfterTime)
        {
            Destroy(this.gameObject);
        }
    }

    #endregion Private Functions
}
