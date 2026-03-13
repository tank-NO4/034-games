using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GlobalFade : MonoBehaviour
{
    // 全局唯一的 FadeController 实例
    public static FadeController instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = GetComponent<FadeController>();
            DontDestroyOnLoad(gameObject); // 关键：切换场景时不销毁
        }
        else
        {
            Destroy(gameObject); // 防止重复创建多个遮罩
        }
    }
}
