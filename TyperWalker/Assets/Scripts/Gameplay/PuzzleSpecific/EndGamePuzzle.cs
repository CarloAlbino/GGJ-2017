using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGamePuzzle : BasePuzzle {

    private GameController m_gameController = null;
    public WordZone m_wz2 = null;
    public string m_completeText2 = "BYE! THANKS FOR HELPING US! WE'LL NEVER FORGET YOUR KINDNESS!!";

    void Start()
    {
        m_gameController = FindObjectOfType<GameController>();
        m_wz2.gameObject.SetActive(false);
    }

    void Update()
    {
        if (m_wordZone.IsPuzzleComplete())
        {
            m_textDisplay.text = m_completeText;
            m_wz2.gameObject.SetActive(true);
        }

        if(m_wz2.IsPuzzleComplete())
        {
            m_textDisplay.text = m_completeText2;
            m_gameController.EndGame();
        }
    }

}
