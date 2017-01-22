using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpPuzzle : BasePuzzle {

    [SerializeField]
    private GameObject m_villager = null;
    [SerializeField]
    private Transform m_safePosition = null;

	void Update ()
    {
        if (m_wordZone.IsPuzzleComplete())
        {
            m_villager.transform.position = m_safePosition.position;
            m_textDisplay.text = m_completeText;
            RemoveBlock();
        }
    }
}
