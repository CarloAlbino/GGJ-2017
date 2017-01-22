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

    // Reference the audio source
    private AudioSource m_audio = null;

    private char[] m_characters = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                                    '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '\'', ':', ',', '!', '-', '.', '+', '?', '"', ';' };

    [SerializeField]
    private AudioClip[] m_characterAudio = new AudioClip[72];
    [SerializeField]
    private AudioClip m_bleepAudio = null;

    void Start()
    {
        m_audio = GetComponent<AudioSource>();
    }

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
                                PlaySound(m_bleepAudio);
                            }
                            else
                            {
                                s = "0";
                                PlaySound(m_characterAudio[36 + 25]);
                            }
                            break;
                        case KeyCode.Alpha1:
                            if (m_isShifted)
                            {
                                s = "!";
                                PlaySound(m_characterAudio[40 + 25]);
                            }
                            else
                            {
                                s = "1";
                                PlaySound(m_characterAudio[27 + 25]);
                            }
                            break;
                        case KeyCode.Alpha2:
                            if (m_isShifted)
                            {
                                s = "@";
                                PlaySound(m_bleepAudio);
                            }
                            else
                            {
                                s = "2";
                                PlaySound(m_characterAudio[28 + 25]);
                            }
                            break;
                        case KeyCode.Alpha3:
                            if (m_isShifted)
                            {
                                s = "$";
                                PlaySound(m_bleepAudio);
                            }
                            else
                            {
                                s = "3";
                                PlaySound(m_characterAudio[29 + 25]);
                            }
                            break;
                        case KeyCode.Alpha4:
                            if (m_isShifted)
                            {
                                s = "%";
                                PlaySound(m_bleepAudio);
                            }
                            else
                            {
                                s = "4";
                                PlaySound(m_characterAudio[30 + 25]);
                            }
                            break;
                        case KeyCode.Alpha5:
                            if (m_isShifted)
                            {
                                s = "%";
                                PlaySound(m_bleepAudio);
                            }
                            else
                            {
                                s = "5";
                                PlaySound(m_characterAudio[31 + 25]);
                            }
                            break;
                        case KeyCode.Alpha6:
                            if (m_isShifted)
                            {
                                s = "^";
                                PlaySound(m_bleepAudio);
                            }
                            else
                            {
                                s = "5";
                                PlaySound(m_characterAudio[32 + 25]);
                            }
                            break;
                        case KeyCode.Alpha7:
                            if (m_isShifted)
                            {
                                s = "&";
                                PlaySound(m_bleepAudio);
                            }
                            else
                            {
                                s = "7";
                                PlaySound(m_characterAudio[33 + 25]);
                            }
                            break;
                        case KeyCode.Alpha8:
                            if (m_isShifted)
                            {
                                s = "*";
                                PlaySound(m_bleepAudio);
                            }
                            else
                            {
                                s = "8";
                                PlaySound(m_characterAudio[34 + 25]);
                            }
                            break;
                        case KeyCode.Alpha9:
                            if (m_isShifted)
                            {
                                s = "(";
                                PlaySound(m_bleepAudio);
                            }
                            else
                            {
                                s = "9";
                                PlaySound(m_characterAudio[35 + 25]);
                            }
                            break;
                        case KeyCode.Comma:
                            if (m_isShifted)
                            {
                                s = "<";
                                PlaySound(m_bleepAudio);
                            }
                            else
                            {
                                s = ",";
                                PlaySound(m_characterAudio[39 + 25]);
                            }
                            break;
                        case KeyCode.Period:
                            if (m_isShifted)
                            {
                                s = ">";
                                PlaySound(m_bleepAudio);
                            }
                            else
                            {
                                s = ".";
                                PlaySound(m_characterAudio[42 + 25]);
                            }
                            break;
                        case KeyCode.Semicolon:
                            if (m_isShifted)
                            {
                                s = ":";
                                PlaySound(m_characterAudio[38 + 25]);
                            }
                            else
                            {
                                s = ";";
                                PlaySound(m_characterAudio[46 + 25]);
                            }
                            break;
                        case KeyCode.Quote:
                            if (m_isShifted)
                            {
                                s = "\"";
                                PlaySound(m_characterAudio[45 + 25]);
                            }
                            else
                            {
                                s = "'";
                                PlaySound(m_characterAudio[37 + 25]);
                            }
                            break;
                        case KeyCode.Minus:
                            if (m_isShifted)
                            {
                                s = "_";
                                PlaySound(m_bleepAudio);
                            }
                            else
                            {
                                s = "-";
                                PlaySound(m_characterAudio[41 + 25]);
                            }
                            break;
                        case KeyCode.Equals:
                            if (m_isShifted)
                            {
                                s = "+";
                                PlaySound(m_characterAudio[43 + 25]);
                            }
                            else
                            {
                                s = "=";
                                PlaySound(m_bleepAudio);
                            }
                            break;
                        case KeyCode.Slash:
                            if (m_isShifted)
                            {
                                s = "?";
                                PlaySound(m_characterAudio[44 + 25]);
                            }
                            else
                            {
                                s = "/";
                                PlaySound(m_bleepAudio);
                            }
                            break;
                        default:
                            if(m_isShifted)
                            {
                                s = key.ToString();
                                for(int i = 0; i < 26; i++)
                                {
                                    if(m_characters[i] == key.ToString().ToLower()[0])
                                    {
                                        PlaySound(m_characterAudio[i + 26]);
                                    }
                                }
                            }
                            else
                            {
                                s = key.ToString().ToLower();
                                for (int i = 0; i < 26; i++)
                                {
                                    if (m_characters[i] == key.ToString().ToLower()[0])
                                    {
                                        PlaySound(m_characterAudio[i]);
                                    }
                                }
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

    private void PlaySound(AudioClip clip)
    {
        if(m_audio != null)
        {
            if (m_audio.isPlaying == false)
            {
                if (clip != null)
                {
                    m_audio.clip = clip;
                    m_audio.Play();
                }
            }
        }
    }
}
