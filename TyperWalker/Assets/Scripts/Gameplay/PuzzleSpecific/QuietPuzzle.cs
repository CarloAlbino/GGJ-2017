using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuietPuzzle : BasePuzzle {

    [SerializeField]
    private Transform m_startPosition = null;
    private GameObject m_player = null;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Move>() != null)
        {
            m_player = other.gameObject;
        }
    }

    public override void SpecialEffect(LetterParticle l)
    {
        base.SpecialEffect(l);
        if(l.GetLetter()[0] != '.')
        {
            if(m_player != null)
            {
                m_player.transform.position = m_startPosition.position;
                m_textDisplay.text = m_completeText;
            }
        }
        else
        {
            l.SetColour(Color.blue);
        }
    }
}
