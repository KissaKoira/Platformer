using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magickball : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject.Destroy(this.gameObject);
    }
}
