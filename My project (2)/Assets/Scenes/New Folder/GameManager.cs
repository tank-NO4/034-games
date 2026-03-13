using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 游戏是否处于暂停状态
    private bool isPaused = false;

    // 暂停面板（需要在 Inspector 中拖拽赋值）
    public GameObject pausePanel;

    void Update()
    {
        // 监听 ESC 键 触发暂停/继续
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    // 暂停游戏
    public void PauseGame()
    {
        isPaused = true;
        // 冻结游戏时间（停止所有基于 Time.deltaTime 的逻辑）
        Time.timeScale = 0f;
        // 显示暂停面板
        if (pausePanel != null)
        {
            pausePanel.SetActive(true);
        }
    }

    // 继续游戏
    public void ResumeGame()
    {
        isPaused = false;
        // 恢复游戏时间
        Time.timeScale = 1f;
        // 隐藏暂停面板
        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }
    }

    // 退出游戏（返回主菜单/关闭游戏）
    public void QuitGame()
    {
        // 先恢复时间，避免下次进入场景时时间被冻结
        Time.timeScale = 1f;

        // 方式1：返回主菜单场景（推荐）
        // SceneManager.LoadScene("MainMenu");

        // 方式2：直接退出游戏（打包后生效，编辑器中不会关闭）
        Application.Quit();
        Debug.Log("游戏已退出");
    }
}