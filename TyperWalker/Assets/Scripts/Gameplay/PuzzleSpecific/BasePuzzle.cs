using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasePuzzle : MonoBehaviour {
    [SerializeField]
    protected GameObject m_roadBlock = null;
    [SerializeField]
    protected Text m_textDisplay = null;
    [SerializeField]
    protected string m_completeText = "<3";
    [SerializeField]
    protected WordZone m_wordZone = null;

    protected void RemoveBlock()
    {
        if (m_roadBlock != null)
        {
            m_roadBlock.SetActive(false);
        }
    }

    public virtual void SpecialEffect(LetterParticle l) { }
}
