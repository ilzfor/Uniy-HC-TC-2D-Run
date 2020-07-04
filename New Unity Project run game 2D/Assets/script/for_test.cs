
using UnityEngine;

public class for_test : MonoBehaviour
{
    private void Start()
    {
        print(Mathf.PI);
        print(Random.value);
        print(Random.Range(100,501));
        print(Mathf.Abs(-91));
    }
    private void Update()
    {
        print(Time.time);
    }
}
