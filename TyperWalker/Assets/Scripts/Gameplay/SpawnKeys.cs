using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKeys : MonoBehaviour {

    [SerializeField, Tooltip("Prefab of the letter particle")]
    private LetterParticle m_letterPrefab = null;

    [SerializeField, Tooltip("Delay before input is detected again")]
    private float m_inputDelay = 0.4f;
    // Count the current delay
    private float m_currentCount = 0.0f;

    [SerializeField, Tooltip("Position where the particle will spawn")]
    private Transform m_spawnPosition = null;

    // Movement direction
    private bool m_rightPressed = false;
    private bool m_leftPressed = false;

    // Capitalize/Shift up the character
    private bool m_isShifted = false;
    // Array of all the keycodes
    private KeyCode[] m_keyArray = {KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D, KeyCode.E, KeyCode.F, KeyCode.G, KeyCode.Q, KeyCode.R,
                                    KeyCode.S, KeyCode.T, KeyCode.V, KeyCode.W, KeyCode.X, KeyCode.Z, KeyCode.Alpha1, KeyCode.Alpha2,
                                    KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha9,
                                    KeyCode.Comma, KeyCode.Period, KeyCode.Semicolon, KeyCode.Quote, KeyCode.Minus, KeyCode.Equals,
                                    KeyCode.Slash, KeyCode.H, KeyCode.I,KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.M, KeyCode.N, KeyCode.O,
                                    KeyCode.P, KeyCode.U, KeyCode.Y, KeyCode.Alpha0};

    void Update ()
    {
        // Set Caps Lock
        if(Input.GetKeyDown(KeyCode.CapsLock))
        {
            m_isShifted = !m_isShifted;
        }

        // Set Shift
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            m_isShifted = !m_isShifted;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            m_isShifted = !m_isShifted;
        }

        // Calculate input delay
        if (m_currentCount > m_inputDelay)
        {
            Detectinput();
            m_currentCount = 0;
        }
        else
        {
            m_currentCount += Time.deltaTime;
        }
    }

    /// <summary>
    /// Detect the key being pressed and set the character string and movement direction
    /// </summary>
    private void Detectinput()
    {
        m_rightPressed = false;
        m_leftPressed = false;
        int iterator = 0;
        foreach(KeyCode key in m_keyArray)
        {
            iterator++;
            if (Input.GetKey(key))
            {
                LetterParticle letter = Instantiate(m_letterPrefab, m_spawnPosition.position, Quaternion.identity) as LetterParticle;
                
                if(letter != null)
                {
                    if(iterator < 22)
                    {
                        m_rightPressed = false;
                        m_leftPressed = true;
                    }
                    else
                    {
                        m_rightPressed = true;
                        m_leftPressed = false;
                    }
                    string s;
                    switch(key)
                    {
                        case KeyCode.Alpha0:
                            if(m_isShifted)
                            {
                                s = ")";
                            }
                            else
                            {
                                s = "0";
                            }
                            break;
                        case KeyCode.Alpha1:
                            if (m_isShifted)
                            {
                                s = "!";
                            }
                            else
                            {
                                s = "1";
                            }
                            break;
                        case KeyCode.Alpha2:
                            if (m_isShifted)
                            {
                                s = "@";
                            }
                            else
                            {
                                s = "2";
                            }
                            break;
                        case KeyCode.Alpha3:
                            if (m_isShifted)
                            {
                                s = "$";
                            }
                            else
                            {
                                s = "3";
                            }
                            break;
                        case KeyCode.Alpha4:
                            if (m_isShifted)
                            {
                                s = "%";
                            }
                            else
                            {
                                s = "4";
                            }
                            break;
                        case KeyCode.Alpha5:
                            if (m_isShifted)
                            {
                                s = "%";
                            }
                            else
                            {
                                s = "5";
                            }
                            break;
                        case KeyCode.Alpha6:
                            if (m_isShifted)
                            {
                                s = "^";
                            }
                            else
                            {
                                s = "6";
                            }
                            break;
                        case KeyCode.Alpha7:
                            if (m_isShifted)
                            {
                                s = "&";
                            }
                            else
                            {
                                s = "7";
                            }
                            break;
                        case KeyCode.Alpha8:
                            if (m_isShifted)
                            {
                                s = "*";
                            }
                            else
                            {
                                s = "8";
                            }
                            break;
                        case KeyCode.Alpha9:
                            if (m_isShifted)
                            {
                                s = "(";
                            }
                            else
                            {
                                s = "9";
                            }
                            break;
                        case KeyCode.Comma:
                            if (m_isShifted)
                            {
                                s = "<";
                            }
                            else
                            {
                                s = ",";
                            }
                            break;
                        case KeyCode.Period:
                            if (m_isShifted)
                            {
                                s = ">";
                            }
                            else
                            {
                                s = ".";
                            }
                            break;
                        case KeyCode.Semicolon:
                            if (m_isShifted)
                            {
                                s = ":";
                            }
                            else
                            {
                                s = ";";
                            }
                            break;
                        case KeyCode.Quote:
                            if (m_isShifted)
                            {
                                s = "\"";
                            }
                            else
                            {
                                s = "'";
                            }
                            break;
                        case KeyCode.Minus:
                            if (m_isShifted)
                            {
                                s = "_";
                            }
                            else
                            {
                                s = "-";
                            }
                            break;
                        case KeyCode.Equals:
                            if (m_isShifted)
                            {
                                s = "+";
                            }
                            else
                            {
                                s = "=";
                            }
                            break;
                        case KeyCode.Slash:
                            if (m_isShifted)
                            {
                                s = "?";
                            }
                            else
                            {
                                s = "/";
                            }
                            break;
                        default:
                            if(m_isShifted)
                            {
                                s = key.ToString();
                            }
                            else
                            {
                                s = key.ToString().ToLower();
                            }
                            break;
                    }
                    letter.SetLetter(s);
                }
            }
        }
    }

    /// <summary>
    /// Returns if the right keys are pressed
    /// </summary>
    /// <returns></returns>
    public bool IsRightPressed()
    {
        return m_rightPressed;
    }

    /// <summary>
    /// Returns if the left keys are pressed
    /// </summary>
    /// <returns></returns>
    public bool IsLeftPressed()
    {
        return m_leftPressed;
    }
}
