using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class FadeController : MonoBehaviour
{
    public Image fadeImage;
    [Tooltip("渐变时间（秒）")]
    public float fadeDuration = 1.5f;

    // 渐白 → 跳场景 → 渐透明
    public IEnumerator FadeToScene(string targetSceneName)
    {
        // 1. 慢慢变白
        float timer = 0;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, timer / fadeDuration);
            fadeImage.color = new Color(1, 1, 1, alpha);
            yield return null;
        }
        fadeImage.color = Color.white;

        // 2. 跳转到目标场景
        SceneManager.LoadScene(targetSceneName);

        // 3. 新场景加载后慢慢变透明
        yield return new WaitForSeconds(0.2f);
        timer = 0;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(1, 0, timer / fadeDuration);
            fadeImage.color = new Color(1, 1, 1, alpha);
            yield return null;
        }
    }
}