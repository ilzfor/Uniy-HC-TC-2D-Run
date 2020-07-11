﻿
using UnityEngine;

public class Learn1_Static : MonoBehaviour
{
    private void Start()
    {
        //靜態成員用法
        //靜態屬性 Property=欄位Fiels(儲存資料)
        //語法:類別名稱,靜態屬性名稱
        print(Mathf.PI);
        print(Random.value);//0-1隨機值
        print(Random.Range(100,501));// 取範圍內隨機值

        print(Mathf.Abs(-91));//絕對值
        //呼叫方法
        Test();
        Test();
        Skill("火焰");
        Skill("水");
        Skill("閃電");
    }
    private void Update()
    {
        print(Time.time);
    }
    //方法
    //1.可以被按鈕呼叫

    //語法
    //修飾詞 傳回類型 方法名稱() {程式內容}
    // void 無傳回
    public void Test()
    {
        print("我是測試方法~");
    }
    public void SkillFire()
    {
        print("施放技能:火焰");
        print("播放音效");
    }public void SkillWater()
    {
        print("施放技能:水");
        print("播放音效");
        //參數:類型 名稱
    }public void Skill(string s)
    {
        print("施放技能:"+s);
        print("播放音效");
    }
    

}
