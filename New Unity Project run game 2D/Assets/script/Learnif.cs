﻿
using UnityEngine;

public class Learnif : MonoBehaviour
{
    public bool test;
    private void Start()
    {
        //如果(布林值){程式內容}
        //作用:當布林值為true才會執行{}程式內容
        if (test)
        {
            print("我是判斷式");
        }
	}
    public bool podo;
    private void Update()
    {
        //當布林值為true會執行if(){}程式內容
        //當布林值為false會執行else{}程式內容
        if (podo)
        {
            print("開門");
        }
        else
        {
            print("關門");
        }
    }
}
