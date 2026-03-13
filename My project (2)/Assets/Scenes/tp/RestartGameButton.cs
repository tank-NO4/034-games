using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartGameButton : MonoBehaviour
{
    void Start()
    {
        // 获取按钮并绑定点击事件
        Button btn = GetComponent<Button>();
        if (btn != null)
        {
            btn.onClick.AddListener(RestartCurrentScene);
        }
    }

    // 重新加载当前场景 = 重新开始游戏
    public void RestartCurrentScene()
    {
        // 打印日志，方便调试
        Debug.Log("点击重新开始游戏，加载当前场景");
        // 加载当前打开的场景
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
