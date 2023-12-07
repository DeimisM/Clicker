using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameManager.clicks++;
    }
}
