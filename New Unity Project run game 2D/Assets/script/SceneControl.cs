using UnityEngine;
using UnityEngine.SceneManagement;//引用 場景管理 API
/// <summary>
/// 場景控制:切換場景、離開遊戲
/// </summary>
public class SceneControl : MonoBehaviour
{
    /// <summary>
    /// 離開遊戲
    /// </summary>
    public void Quit()
    {
        Application.Quit(); //應用程式,離開()
    }

    /// <summary>
    /// 載入場景
    /// </summary>
    public void LoadScene()
    {
        SceneManager.LoadScene("遊戲畫面"); //場景管理,載入場景("載入場景")
    }
    /// <summary>
    /// 延遲載入場景
    /// </summary>
    public void DelayLoadScene()
    {
        //延遲呼叫("方法名稱",延遲時間)
        Invoke("LoadScene", 0.8f);
    }
    public void DelayQuit()
    {
        Invoke("Quit", 0.8f);
    }
}
