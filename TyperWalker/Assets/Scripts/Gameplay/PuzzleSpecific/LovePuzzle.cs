using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LovePuzzle : BasePuzzle {

    [SerializeField]
    private GameObject m_crying = null;
    [SerializeField]
    private GameObject m_hearts = null;

	void Update ()
    {
		if(m_wordZone.IsPuzzleComplete())
        {
            m_crying.SetActive(false);
            m_hearts.SetActive(true);
            m_textDisplay.text = m_completeText;
            RemoveBlock();
        }
        else
        {
            m_crying.SetActive(true);
            m_hearts.SetActive(false);
        }
	}
}
