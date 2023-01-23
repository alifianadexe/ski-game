using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameM : MonoBehaviour
{
    //Race Over Popup UI
    public GameObject raceOverUI;
    // Overlay UI Image for screen transitions
    public GameObject overLayScreen;
    //The Scene Build Index for our next level ( set in File-->Build Settings 0
    public int nextScendIndex;


    private void OnEnable()
    {
        GameEvents.OnRaceStop += ShowRaceOverUI;
        GameEvents.OnRetryRace += RestartRace;
        GameEvents.OnQuitGame += ShutDownGame;
        GameEvents.OnNextLevel += NextLevel;
    }

    private void OnDisable()
    {
        GameEvents.OnRaceStop -= ShowRaceOverUI;
        GameEvents.OnRetryRace -= RestartRace;
        GameEvents.OnQuitGame -= ShutDownGame;
        GameEvents.OnNextLevel -= NextLevel;

    }

    // Start is called before the first frame update
    void Start()
    {
        //At the start of our scene we will fade out the Overlay
        overLayScreen.GetComponent<Image>().CrossFadeAlpha(0, 1, false);
    }

    private void ShowRaceOverUI()
    {
        //turn on the game object
        raceOverUI.SetActive(true);
    }

    private void RestartRace()
    {
        // reloads the game scene after pressing the start button (only after the player has reached the finish line
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void NextLevel()
    {
        StartCoroutine(ChangeLevel());
    }


    private IEnumerator ChangeLevel()
    {
        overLayScreen.GetComponent<Image>().CrossFadeAlpha(1, 1, false);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(nextScendIndex);
    }


    private IEnumerator ShutDownGame()
    {
        //to simulate the game quitting we
        overLayScreen.GetComponent<Image>().CrossFadeColor(new Color(0, 0, 0, 1), 1, false, true);
        yield return new WaitForSeconds(1);
        // closes the game entirely (only when playing the build)
        Application.Quit();
        print("The Game Has Quit");
    }
}
