using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Buttons : MonoBehaviour
{
    private Animator anim;
    private GameObject gameUI;
    private GameObject pausedUI;
    private GameObject statsUI;
    private bool paused;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isFading", false);
        gameUI = gameObject.transform.GetChild(0).gameObject;
        pausedUI = gameObject.transform.GetChild(1).gameObject;
        statsUI = gameObject.transform.GetChild(2).gameObject;
        paused = false;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;

                paused = true;

                gameUI.SetActive(false);
                pausedUI.SetActive(true);
            }
            else
            {
                Time.timeScale = 1f;
                Cursor.lockState = CursorLockMode.Locked;

                paused = false;

                gameUI.SetActive(true);
                pausedUI.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!paused)
            {
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;

                paused = true;

                gameUI.SetActive(false);
                statsUI.SetActive(true);
            }
            else
            {
                Time.timeScale = 1f;
                Cursor.lockState = CursorLockMode.Locked;

                paused = false;

                gameUI.SetActive(true);
                statsUI.SetActive(false);
            }
        }
    }

    #region Pregame and Postgame
    public void StartGame()
    {
        anim.SetBool("isFading", true);
        StartCoroutine("LoadGame");
    }

    public void ResumeGame()
    {
        StartCoroutine("Resume");
    }

    public void Options()
    {
        anim.SetBool("isFading", true);
        StartCoroutine("LoadOptions");
    }

    public void Controls()
    {
        anim.SetBool("isFading", true);
        StartCoroutine("LoadControls");
    }

    public void Credits()
    {
        anim.SetBool("isFading", true);
        StartCoroutine("LoadCredits");
    }

    public void MainMenu()
    {
        anim.SetBool("isFading", true);
        StartCoroutine("LoadMainMenu");
    }

    public void PleaseRead()
    {
        anim.SetBool("isFading", true);
        StartCoroutine("LoadPleaseRead");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    #region Coroutines
    IEnumerator LoadGame()
    {
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("MainScene");
    }
    IEnumerator Resume()
    {
        yield return new WaitForSeconds(0.5f);
        gameUI.SetActive(true);

        yield return new WaitForSeconds(0.5f);
        pausedUI.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }
    IEnumerator LoadOptions()
    {
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("OptionsScene");
    }
    IEnumerator LoadControls()
    {
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("ControlsScene");
    }
    IEnumerator LoadCredits()
    {
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("CreditsScene");
    }
    IEnumerator LoadMainMenu()
    {
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("StartGameScene");
    }

    IEnumerator LoadPleaseRead()
    {
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("PleaseRead");
    }
    #endregion
    #endregion
}
