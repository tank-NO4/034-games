using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeController : MonoBehaviour
{
    // 拖拽赋值：白屏 Image 组件
    public Image fadeImage;
    // 淡入淡出时长（秒）
    public float fadeDuration = 1f;

    // 白屏过渡 + 传送的协程
    public IEnumerator FadeToWhiteAndTeleport(Transform player, Transform targetTP)
    {
        // 1. 渐入白屏（从透明到不透明）
        float timer = 0;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            fadeImage.color = new Color(1, 1, 1, Mathf.Lerp(0, 1, timer / fadeDuration));
            yield return null;
        }

        // 2. 传送玩家到目标点
        player.position = targetTP.position;

        // 3. 渐出白屏（从不透明到透明）
        timer = 0;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            fadeImage.color = new Color(1, 1, 1, Mathf.Lerp(1, 0, timer / fadeDuration));
            yield return null;
        }
    }
}