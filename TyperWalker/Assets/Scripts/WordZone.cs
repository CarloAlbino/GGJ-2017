using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordZone : MonoBehaviour {

    [SerializeField]
    private string m_word = "empty";
    [SerializeField]
    private Color m_wordColour = Color.white;
    private List<LetterParticle> m_letters = new List<LetterParticle>();
    private bool m_wordComplete = false;

	void Start ()
    {
	}
	
	void Update ()
    {
        if (m_word.Length <= 0)
        {
            foreach(LetterParticle l in m_letters)
            {
                l.SetColour(m_wordColour);
            }
        }
	}

    public void CheckForWord(LetterParticle l)
    {
        if (l != null)
        {
            for (int i = 0; i < m_word.Length; i++)
            {
                if (m_word.ToLower()[i] == l.GetLetter()[0])
                {
                    l.StopDestruction();
                    l.SetLayer(10);
                    m_letters.Add(l);
                    string tempWord = "";
                    foreach(char c in m_word.ToLower())
                    {
                        if(c != l.GetLetter()[0])
                        {
                            tempWord += c;
                        }
                    }
                    m_word = tempWord;
                    break;
                }
            }
        }
    }
}
