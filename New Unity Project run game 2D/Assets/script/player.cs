
using UnityEngine;

public class player : MonoBehaviour
{
    //單行註解
    /*多行註解
     *多行註解
     *
     */
#region 欄位區域
    //命名規則
    //1.有意義的名稱
    //2.不要用數字開頭
    //3.不要用特殊符號:@#/*空格
    //4.可以使用中文

    //欄位語法
    //修飾詞 類型 欄位名稱=值;
    //沒有 = 值
    //整數，浮點數 預設值 0
    //字串 預設值""
    //布林值 false

    //私人 private- 僅限此類別可用|不會顯示
    //公開 public-所有類別皆可用|會顯示

    //欄位屬性
    //標題 Header
    //提示 Tooltip
    //範圍 Range

    [Header("速度"), Tooltip("腳色移動速度"), Range(10, 1500)]
    public int speed = 50;
    [Tooltip("腳色血量")]
    public float HP = 999.9f;
    [Tooltip("金幣")]
    public int coin;
    [Tooltip("跳躍高度"),Range(100, 200)]
    public int heignt = 500;
    [Tooltip("跳躍音效")]
    public AudioClip sounjump;
    [Tooltip("攻擊音效")]
    public AudioClip sounat;
    [Tooltip("滑行音效")]
    public AudioClip sounhy;
    [Tooltip("碰撞音效")]
    public AudioClip soungethit;
    [Tooltip("死亡確認")]
    public bool dead;

    [Header("動畫控制器")]
    public Animator ani;
    #endregion
# region 方法區域
    /// <summary>
    /// 腳色跳躍的高度速度
    /// </summary>
    private void jump()
    {
        //布林值=輸入,取得按鍵(按鍵代碼列舉,左邊ctrl)

        bool key2 = Input.GetKey(KeyCode.Space);

        ani.SetBool("跳躍",key2);

    }
    /// <summary>
    /// 腳色滑行時的速度和體積變化
    /// </summary>
    private void slide()
    {

       bool key =Input.GetKey(KeyCode.LeftControl);

        ani.SetBool("滑行",key);
    }
    /// <summary>
    /// 腳色攻擊的素質
    /// </summary>
    private void at()
    {

    }
    /// <summary>
    /// 金幣數值和金幣計算
    /// </summary>
    private void getcoin()
    {

    }
    /// <summary>
    ///腳色死亡後的相關計算 
    /// </summary>
    private void Dead()
    {

    }
    /// <summary>
    /// 碰撞障礙後的相關計算
    /// </summary>
    private void hti()
    {
        
    }
    #endregion
    #region 事件區域
    //開始 Start
    //播放遊戲時執行一次
    //初始化:
    private void Start()
    {
      
       
    }
    //更新 Update
    //播放遊戲後一秒直行約60次-60FPS
    //移動、監聽玩家鍵盤、滑鼠與觸控
    private void Update()
    {
        jump();
        slide();
    }
    #endregion
}