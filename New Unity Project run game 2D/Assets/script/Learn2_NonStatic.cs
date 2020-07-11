
using UnityEngine;

public class Learn2_NonStatic : MonoBehaviour
{
    //儲存場景上的物件或元件
    public GameObject man;

    public Transform manTran;

    public Camera Cam;

    public ParticleSystem ps;
    //存取
    //非靜態屬性

    private void Start()
    {
        //取得
        print(man.tag);
        print(man.layer);

        //存放
        manTran.position = new Vector3(-47, 7, 0);
        //manTrab.localScale = new Vector3(0, 0, 0);
    }
    private void Update()
    {
        //非靜態方法
        //manTran.Rotate(0,0,0);
        manTran.Translate(0.1f, 0, 0);
    }
}