using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryTrigger : MonoBehaviour
{
    public FadeController fadeController;
    [Tooltip("要回到的场景名")]
    public string returnSceneName = "StartScene";

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(" 触发胜利！开始渐变白屏...");
            // 启动渐变+跳转
            StartCoroutine(fadeController.FadeToScene(returnSceneName));
        }
    }
}

