using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    private FadeCamera m_fade = null;
    public float m_timeToShutdown = 5.0f;
    public GameObject m_shutdownCanvas = null;
    
	void Start ()
    {
        m_fade = FindObjectOfType<FadeCamera>();
        m_shutdownCanvas.SetActive(false);
	}

    void Update()
    {
        if (!m_shutdownCanvas.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                m_shutdownCanvas.SetActive(true);
            #if UNITY_WEBGL
                m_shutdownCanvas.GetComponentInChildren<Text>().text = "QUIT GAME?\nPress ENTER to restart game\nPress ESC to return to game";
            #endif
            #if UNITY_STANDALONE
                m_shutdownCanvas.GetComponentInChildren<Text>().text = "QUIT GAME?\nPress ENTER to quit game\nPress ESC to return to game";
            #endif
            #if UNITY_EDITOR
                m_shutdownCanvas.GetComponentInChildren<Text>().text = "QUIT GAME?\nPress ENTER to restart game\nPress ESC to return to game";
            #endif
            }
        }   
        else
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                m_shutdownCanvas.SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                EndGame();
            }
        }
    }

    public void EndGame()
    {
        StartCoroutine(ShutdownAfterTime());
    }

    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(m_timeToShutdown * 0.5f);
        m_fade.FadeIn();
    }

    private IEnumerator ShutdownAfterTime()
    {
        yield return new WaitForSeconds(3);
        m_fade.FadeOut();
        yield return new WaitForSeconds(m_timeToShutdown);
        Application.Quit();
        Debug.Log("Game Shutdown.");
        yield return new WaitForSeconds(1);
        // If not on standalone the game will reset (used for editor and web)
        SceneManager.LoadScene(0);
    }
}
