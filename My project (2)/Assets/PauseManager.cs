using UnityEngine;

public class PauseManager : MonoBehaviour
{
    // 暂停游戏
    public void Pause()
    {
        Time.timeScale = 0f;
        Debug.Log("游戏暂停");
    }

    // 继续游戏
    public void Resume()
    {
        Time.timeScale = 1f;
        Debug.Log("游戏继续");
    }
}