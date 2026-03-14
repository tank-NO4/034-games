using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public string continueSceneName = "ContinueScene";
    public string startSceneName = "StartScene";
    public float delayInContinue = 3f;

    public static SceneTransitionManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartExitSequence()
    {
        Time.timeScale = 1f; // 确保时间正常
        StartCoroutine(ExitSequence());
    }

    IEnumerator ExitSequence()
    {
        SceneManager.LoadScene(continueSceneName);
        yield return null;
        yield return new WaitForSeconds(delayInContinue);
        SceneManager.LoadScene(startSceneName);
    }
}