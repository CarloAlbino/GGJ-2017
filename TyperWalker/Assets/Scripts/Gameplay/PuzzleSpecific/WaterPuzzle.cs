using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPuzzle : BasePuzzle {

    [SerializeField]
    private GameObject m_fire = null;

    void Update ()
    {
        if (m_wordZone.IsPuzzleComplete())
        {
            m_fire.SetActive(false);
            m_textDisplay.text = m_completeText;
            RemoveBlock();
        }
        else
        {
            m_fire.SetActive(true);
        }
    }
}
