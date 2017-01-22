using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeCamera : MonoBehaviour {

    public CanvasGroup m_fadeCanvas = null;
    public float m_fadeSpeed = 1.0f;

    public bool m_fadeIn = false;

    void Update()
    {
        if(m_fadeIn)
        {
            if(m_fadeCanvas.alpha > 0)
            {
                m_fadeCanvas.alpha = Mathf.Lerp(m_fadeCanvas.alpha, 0, m_fadeSpeed * Time.deltaTime);
            }
        }
        else
        {
            if (m_fadeCanvas.alpha < 1)
            {
                m_fadeCanvas.alpha = Mathf.Lerp(m_fadeCanvas.alpha, 1, m_fadeSpeed * Time.deltaTime);
            }
        }
    }

    public void FadeIn()
    {
        m_fadeIn = true;
    }

    public void FadeOut()
    {
        m_fadeIn = false;
    }
}
