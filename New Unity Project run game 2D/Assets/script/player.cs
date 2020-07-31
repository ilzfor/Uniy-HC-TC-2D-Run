
using UnityEngine;
using UnityEngine.UI;

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
    [Header("金幣文字")]
    public Text textcoin;

    [Header("速度"), Tooltip("腳色移動速度"), Range(1, 1500)]

    public int speed = 50;
    [Tooltip("腳色血量")]
    public float HP = 500;
    [Tooltip("金幣")]
    public int coin;
    [Tooltip("跳躍高度"), Range(10, 1000)]
    public int heignt = 500;
    [Tooltip("跳躍音效")]
    public AudioClip sounjump;
    [Tooltip("攻擊音效")]
    public AudioClip sounat;
    [Tooltip("滑行音效")]
    public AudioClip sounhy;
    [Tooltip("碰撞音效")]
    public AudioClip soungethit;
    [Tooltip("金幣音效")]
    public AudioClip soungetcoin;
    [Tooltip("死亡確認")]
    public bool dead;

    [Header("動畫控制器")]
    public Animator ani;
    [Header("膠囊碰撞器")]
    public CapsuleCollider2D cc2d;
    [Header("剛體")]
    public Rigidbody2D rig;
    public bool isGround;

    [Header("血條")]
    public Image imghp;
    private float hpMax;
    [Header("音效")]
    public AudioSource and;
    [Header("遊戲結束")]
    public GameObject final;
    [Header("標題")]
    public Text textTitle;
    [Header("本次金幣數量")]
    public Text textCurrent;
    #endregion
    #region 方法區域
    /// <summary>
    /// 跑步
    /// </summary>
    private void Move()
    {
        if (rig.velocity.magnitude < 4.3)
        {
            //剛體,添加推力(二維向量)
            rig.AddForce(new Vector2(speed, 0));
        }

    }
    /// <summary>
    /// 腳色跳躍的高度速度
    /// </summary>
    private void Jump()
    {
        //布林值=輸入,取得按鍵(按鍵代碼列舉,左邊ctrl)

        bool key2 = Input.GetKeyDown(KeyCode.Space);
        // 顛倒運算子!
        //作用:將布林值變成相反
        //!true---false
        ani.SetBool("跳躍", !isGround);
        

        //如果在地板上
        if (isGround)
        {
            if (key2)
            {
                and.PlayOneShot(sounjump);
                isGround = false;//不在地板上
                rig.AddForce(new Vector2(0, heignt));//剛體,添加推力(二維向量) 
            }
        }
    }
    /// <summary>
    /// 腳色滑行時的速度和體積變化
    /// </summary>
    private void slide()
    {

        bool key = Input.GetKey(KeyCode.LeftControl);
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            and.PlayOneShot(sounhy);
        }
        ani.SetBool("滑行", key);
        if (key)
        {
            cc2d.offset = new Vector2(-0.328f, -1.44f);//位移

            cc2d.size = new Vector2(1.925f, 2.018f);//尺寸

        }
        else
        {
            cc2d.offset = new Vector2(-0.328f, -0.4425f);//位移

            cc2d.size = new Vector2(1.925f, 4.013f);//尺寸
        }

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
    private void getcoin(Collider2D collision)
    {
        coin++;
        Destroy(collision.gameObject);
        textcoin.text = "金幣:" + coin;
        and.PlayOneShot(soungetcoin);
        HP += 10;
        imghp.fillAmount = HP / hpMax;
    }
    /// <summary>
    ///腳色死亡後的相關計算 
    /// </summary>
    private void Dead()
    {
        HP = 0;
        imghp.fillAmount = HP / hpMax;
        if (dead) return;
        speed = 0;
        dead = true;
        ani.SetTrigger("死亡觸發");
        final.SetActive(true);
        textTitle.text = "嫩";
        textCurrent.text = "本次金幣數量" + coin;
        speed = 0;
        rig.velocity = Vector3.zero;
    }
    /// <summary>
    /// 過關
    /// </summary>
    private void pass()
    {
        final.SetActive(true);
        textTitle.text = "恭喜通關";
        textCurrent.text = "本次金幣數量" + coin;
        speed = 0;
        rig.velocity = Vector3.zero;
    }
    /// <summary>
    /// 碰撞障礙後的相關計算
    /// </summary>
    private void hit()
    {
        HP -= 50;
        imghp.fillAmount = HP / hpMax;
        and.PlayOneShot(soungethit);
        if (HP <= 0) Dead();



    }
    #endregion
    #region 事件區域
    //開始 Start
    //播放遊戲時執行一次
    //初始化:
    private void Start()
    {
        hpMax = HP;

    }
    //更新 Update
    //播放遊戲後一秒直行約60次-60FPS
    //移動、監聽玩家鍵盤、滑鼠與觸控
    private void Update()
    {
        if (dead) return;
        if (transform.position.y <= -7) Dead();


        slide();
    }
    /// <summary>
    /// 一秒固定執行50次 有剛體就用這個執行
    /// </summary>
    private void FixedUpdate()
    {
        if (dead) return;
        Jump();
        Move();
    }
    /// <summary>
    /// 碰撞事件:碰到物件開始執行一次
    /// </summary>
    /// <param name="collision">碰到物件的碰撞資料</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //如果碰到物件的名稱等於"地板"
        if (collision.gameObject.name == "地板")

        {
            //是否在地板上=是
            isGround = true;
        }
        if (collision.gameObject.name == "浮空地板")

        {
            //是否在地板上=是
            isGround = true;
        }


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "金幣")
        {
            getcoin(collision);
        }
        if (collision.tag == "障礙物")
        {
            hit();
        }
    if (collision.name== "粒子效果")
	{
            pass();
	}
    }
    #endregion
}