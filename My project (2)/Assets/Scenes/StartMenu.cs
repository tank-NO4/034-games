using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // 开始游戏
    public void 开始游戏()
    {
        
        SceneManager.LoadScene("SampleScene");
    }

    // 打开设置
    public void 打开设置()
    {
        Debug.Log("打开设置面板");
    }

    // 退出游戏
    public void 退出游戏()
    {
        Application.Quit();
    }
}

