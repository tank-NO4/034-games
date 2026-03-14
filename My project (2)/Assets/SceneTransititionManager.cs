using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    [Header("过渡场景设置")]
    public string continueSceneName = "ContinueScene";   // 过渡场景名称
    public string startSceneName = "StartScene";         // 目标场景名称
    public float delayInContinue = 3f;                    // 在过渡场景停留的时间（秒）

    // 单例模式方便调用（可选）
    public static SceneTransitionManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 使管理器在场景切换时不被销毁
        }
        else
        {
            Destroy(gameObject);
        } 
        Debug.Log("GameManager is alive: " + gameObject.name, gameObject);

    }

    // 开始退出流程：先加载过渡场景，等待 delayInContinue 秒，再加载目标场景
    public void StartExitSequence()
    {
        StartCoroutine(ExitSequence());
    }

    IEnumerator ExitSequence()
    {
        // 1. 加载过渡场景
        SceneManager.LoadScene(continueSceneName);

        // 2. 等待一帧，确保过渡场景已经激活（可选）
        yield return null;

        // 3. 在过渡场景中停留指定时间
        yield return new WaitForSeconds(delayInContinue);

        // 4. 加载目标场景（StartScene）
        SceneManager.LoadScene(startSceneName);
    }
}