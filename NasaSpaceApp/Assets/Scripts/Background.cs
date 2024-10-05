using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float speed = 0.1f;
    public GameObject bg1;
    public GameObject bg2;

    void Update()
    {
        bg1.transform.position += Vector3.left * speed * Time.deltaTime;
        bg2.transform.position += Vector3.left * speed * Time.deltaTime;
        if (bg1.transform.position.x <= -20)
        {
            bg1.transform.position = new Vector3(20, 0, 0);
        }
        if (bg2.transform.position.x <= -20)
        {
            bg2.transform.position = new Vector3(20, 0, 0);
        }
    }
}
