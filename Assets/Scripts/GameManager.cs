using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int sacrificesRequired;
    public int sacrificesAcquired;

    public PlayerController player;
    public Image crosshair;

    public Camera endCam;
    public Narration narratorPanel;
    public TMP_Text narratorText;
    public Button mainMenuBtn;

    public TMP_Text sacrificesCountText;

    // Start is called before the first frame update
    void Start()
    {
        player.canMove = false;
    }


    public void StartGame()
    {
        player.canMove = true;
    }

    public void SacrificeCollected()
    {
        sacrificesAcquired++;
        sacrificesCountText.SetText("Sacrifices: " + sacrificesAcquired + "/" + sacrificesRequired);
        CheckSacrificesComplete();
    }

    public void CheckSacrificesComplete()
    {
        if(sacrificesAcquired == sacrificesRequired)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        player.canMove = false;
        FindObjectOfType<SoundManager>().PlayLaugh();
        narratorPanel.EndGameSequence();
    }

    public void GameEnding()
    {
        FindObjectOfType<PumpkinMoon>().StartRain();
        endCam.enabled = true;
        crosshair.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        StartCoroutine(ShowMainMenuButton(10f));
    }

    private IEnumerator ShowMainMenuButton(float time)
    {
        yield return new WaitForSeconds(time);
        mainMenuBtn.gameObject.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
