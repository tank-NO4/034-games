using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerDestroyTracker : MonoBehaviour
{
    // 记录最后一次触发销毁的原因（默认未知）
    private string _destroyCause = "未知原因";
    // 记录触发销毁的物体名称
    private string _destroySource = "无来源";

    // 【核心方法】：在任何要销毁玩家的地方，先调用这个方法记录原因
    public void MarkDestroyCause(string cause, string source = "未知来源")
    {
        _destroyCause = cause;
        _destroySource = source;
    }

    // 玩家被销毁时自动打印日志（Unity 生命周期）
    void OnDestroy()
    {
        // 打印完整的销毁信息，方便你在 Console 里定位问题
        Debug.LogError($"[玩家销毁追踪] 原因：{_destroyCause} | 触发来源：{_destroySource} | 时间：{Time.time:F2}s");
    }
}

