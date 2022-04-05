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
        IntersceneData.deathCounts++;
        IntersceneData.LoadNextScene(SceneManager.GetActiveScene().name);
    }

    public void onWin()
    {
        IntersceneData.deathCounts = 0;
        IntersceneData.finalAchieved = true;
        IntersceneData.LoadNextScene(SceneManager.GetActiveScene().name);
    }

    public void easyMode()
    {
        OxygenManager.instance.addOxygen(3600f);
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }


    bool easyTriggered;
    private void Update()
    {
        if(!easyTriggered)
        {
            if(IntersceneData._this)
            {
                easyTriggered = true;
                easyMode();
            }
        }

        if ((Input.GetKeyDown(KeyCode.Escape) || pauseMenu.activeSelf) && !GameStopped)
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
            gameObject.SetActive(false);
        }
    }

}
