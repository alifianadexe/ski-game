using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class TitleScreenManager : MonoBehaviour
{
    public CanvasGroup buttonsGroup;
    public CanvasGroup quitCheckGroup;
    public Image overlayImage;
    public int loadLevelID;
    public float fadeTime;


    public void ShowQuitCheck()
    {
        
        quitCheckGroup.DOFade(1, fadeTime);
        buttonsGroup.interactable = false;
        buttonsGroup.DOFade(0, fadeTime);
    }

    public void HideQuitCheck()
    {
        quitCheckGroup.DOFade(0, fadeTime);
        buttonsGroup.interactable = true;
        buttonsGroup.DOFade(1, fadeTime);
    }

    public void QuitGame()
    {
        StartCoroutine("ExitGame");
    }

    private IEnumerator ExitGame()
    {
        overlayImage.DOFade(1, 1);
        yield return new WaitForSeconds(1.0f);
        Application.Quit();
    }

    public void PlayGame()
    {
        StartCoroutine("LoadSceneAsync");
    }

    private IEnumerator LoadSceneAsync()
    {
        overlayImage.DOFade(1,0.5f);
        yield return new WaitForSeconds(0.5f);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(loadLevelID);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }


}
