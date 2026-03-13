using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TeleportWithFade : MonoBehaviour
{
    // 白屏过渡的 Image（拖入 UI 里的白色全屏 Image）
    [Header("白屏过渡图片")]
    public Image fadeImage;

    // 淡入淡出的总时长（秒）
    [Header("过渡时长")]
    public float fadeDuration = 1f;

    // 目标传送点（拖入目标 Transform）
    [Header("目标传送点")]
    public Transform targetTeleportPoint;

    // 玩家标签（默认 "Player"，确保你的玩家对象有这个 Tag）
    private const string PlayerTag = "Player";

    // 触发传送的入口方法（可由碰撞/按钮调用）
    public void StartTeleport()
    {
        // 找到玩家
        GameObject player = GameObject.FindWithTag(PlayerTag);
        if (player == null)
        {
            Debug.LogError("找不到 Tag 为 Player 的玩家对象！");
            return;
        }

        // 启动过渡+传送协程
        StartCoroutine(FadeAndTeleportCoroutine(player.transform));
    }

    // 核心协程：白屏淡入 → 传送 → 白屏淡出
    private IEnumerator FadeAndTeleportCoroutine(Transform playerTransform)
    {
        // 1. 渐入白屏（透明 → 不透明）
        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            fadeImage.color = new Color(1f, 1f, 1f, alpha);
            yield return null;
        }

        // 2. 执行传送：把玩家挪到目标点
        playerTransform.position = targetTeleportPoint.position;
        Debug.Log($"玩家已传送到：{targetTeleportPoint.name}");

        // 3. 渐出白屏（不透明 → 透明）
        timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            fadeImage.color = new Color(1f, 1f, 1f, alpha);
            yield return null;
        }
    }

    // --- 可选：碰撞触发传送 ---
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(PlayerTag))
        {
            StartTeleport();
        }
    }
}
