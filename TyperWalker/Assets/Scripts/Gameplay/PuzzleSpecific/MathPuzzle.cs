using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathPuzzle : BasePuzzle {

	void Update ()
    {
        if (m_wordZone.IsPuzzleComplete())
        {
            m_textDisplay.text = m_completeText;
            RemoveBlock();
        }
    }
}
