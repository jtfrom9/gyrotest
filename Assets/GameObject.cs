using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameObject : MonoBehaviour
{
    public Text text;
    Quaternion rotate;

    void Start()
    {
        Input.gyro.enabled = true;
        rotate = Input.gyro.attitude;
    }

    void Update()
    {
        GyroModifyCamera();
        text.text = $"{transform.rotation.eulerAngles} =  {Input.gyro.attitude.eulerAngles} - {rotate.eulerAngles}";
    }

    void GyroModifyCamera()
    {
        // transform.rotation = GyroToUnity(Input.gyro.attitude);
        var current = GyroToUnity(Input.gyro.attitude).eulerAngles;
        transform.rotation = Quaternion.Euler(current - rotate.eulerAngles);

    }

    private static Quaternion GyroToUnity(Quaternion q)
    {
        // return new Quaternion(q.x, q.y, -q.z, -q.w);
        q.x *= -1;
        q.y *= -1;
        return Quaternion.Euler(90, 0, 0) * q;

        // var e = q.eulerAngles;
        // return Quaternion.Euler(e.x + 90, e.z, e.y);
    }

    public void Reset()
    {
        rotate = GyroToUnity(Input.gyro.attitude);
    }
}
