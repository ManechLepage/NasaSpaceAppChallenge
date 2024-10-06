using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextManager : MonoBehaviour
{
    public void Clicked()
    {
        GameManager.instance.ChangeScene("Game");
    }
}
