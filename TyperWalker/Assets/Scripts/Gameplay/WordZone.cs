using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordZone : MonoBehaviour {

    [SerializeField, Tooltip("The word that will complete the word zone")]
    private string m_word = "empty";
    [SerializeField, Tooltip("The colour the word will turn to when the word is complete")]
    private Color m_wordColour = Color.white;
    [SerializeField, Tooltip("The layer that the particles will change to when the correct letters enter the zone")]
    private int m_newLayerInt = 10;
    [SerializeField, Tooltip("Glow")]
    private GameObject m_glowObject = null;
    [SerializeField, Tooltip("CCan the word be only typed once?")]
    private bool m_typeOnce = true;
    [SerializeField, Tooltip("Case sensitive?")]
    private bool m_caseSensitive = false;

    // Stores refereneces to the letters
    private List<LetterParticle> m_letters = new List<LetterParticle>();

	void Update ()
    {
        // if the word is complete set the colour of the letters to m_wordColour
        if (m_glowObject.activeInHierarchy)
        {
            if (m_word.Length <= 0)
            {
                foreach (LetterParticle l in m_letters)
                {
                    l.SetColour(m_wordColour);
                    if (m_glowObject != null)
                    {
                        m_glowObject.SetActive(false);
                    }
                }
            }
        }
	}

    /// <summary>
    /// Check to see if the letter in the word zone word.
    /// </summary>
    /// <param name="l">Reference to the eltter particle that contains the letter.</param>
    public void CheckForWord(LetterParticle l)
    {
        if (l != null)
        {
            for (int i = 0; i < m_word.Length; i++)
            {
                if (!m_caseSensitive)
                {
                    if (m_word.ToLower()[i] == l.GetLetter().ToLower()[0])
                    {
                        if (m_typeOnce)
                        {
                            // Add letter to the word zone
                            l.StopDestruction();
                            l.SetLayer(m_newLayerInt);
                            m_letters.Add(l);

                            // Remove letter from m_word
                            string tempWord = "";
                            foreach (char c in m_word.ToLower())
                            {
                                if (c != l.GetLetter().ToLower()[0])
                                {
                                    tempWord += c;
                                }
                            }
                            m_word = tempWord;

                            break;
                        }
                        else
                        {
                            if (m_letters.Count < 15)
                            {
                                // Add letter to the word zone
                                l.StopDestruction();
                                l.SetLayer(m_newLayerInt);
                                l.SetColour(m_wordColour);
                                m_letters.Add(l);
                            }
                        }
                    }
                }
                else
                {
                    if (m_word[i] == l.GetLetter()[0])
                    {
                        if (m_typeOnce)
                        {
                            // Add letter to the word zone
                            l.StopDestruction();
                            l.SetLayer(m_newLayerInt);
                            m_letters.Add(l);

                            // Remove letter from m_word
                            string tempWord = "";
                            foreach (char c in m_word)
                            {
                                if (c != l.GetLetter()[0])
                                {
                                    tempWord += c;
                                }
                            }
                            m_word = tempWord;

                            break;
                        }
                        else
                        {
                            if (m_letters.Count < 15)
                            {
                                // Add letter to the word zone
                                l.StopDestruction();
                                l.SetLayer(m_newLayerInt);
                                l.SetColour(m_wordColour);
                                m_letters.Add(l);
                            }
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// Returns if the puzzle is complete.
    /// </summary>
    /// <returns>State of the puzzle completeness.</returns>
    public bool IsPuzzleComplete()
    {
        if(m_word.Length <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
