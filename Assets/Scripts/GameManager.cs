using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public GameObject pauseMenu;

    public Inventory inventory;

    public bool GameStopped { get; private set; }

    public void ContinueGame()
    {
        GameStopped = false;
        PlayerMovement.Instance.enabled = true;
        Time.timeScale = 1f;
    }

    public void StopGame()
    {
        GameStopped = true;
        Time.timeScale = 0f;
        PlayerMovement.Instance.enabled = false;
    }

    public void onDeath()
    {
        IntersceneData.LoadNextScene(SceneManager.GetActiveScene().name);
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape) || pauseMenu.activeSelf) && !GameStopped)
        {
            pauseMenu.SetActive(true);
            gameObject.SetActive(false);
        }
    }

}
