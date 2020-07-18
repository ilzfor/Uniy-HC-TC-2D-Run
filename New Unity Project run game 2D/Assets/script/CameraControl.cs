
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [Header("追蹤目標")]
    public Transform target;
    [Header("追蹤速度"), Range(0, 100)]
    public float speed = 5;
    [Header("攝影機Y軸限制")]
    public Vector2 limitY = new Vector2(0, 2);
    /// <summary>
    /// 攝影機追蹤
    /// </summary>
    private void Track()
    {
        Vector3 a = transform.position;//A=攝影機
        Vector3 b = target.position;//B=目標
        b.z = -10;//Z軸=-10
        //插植(A,B,百分比)
        a = Vector3.Lerp(a, b, Time.deltaTime * speed);
        //a.y=數學函式夾住(a.y,最大,最小)
        a.y = Mathf.Clamp(a.y, limitY.x, limitY.y);
        //攝影機,座標=A
        transform.position = a;

    }
    //Update先執行
    //LateUpdate
    private void LateUpdate()
    {
        Track();
    }


}
