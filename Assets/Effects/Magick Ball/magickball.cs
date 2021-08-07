﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magickball : MonoBehaviour
{
    public GameObject magick_effect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Instantiate(magick_effect).transform.position = this.transform.position;
        GameObject.Destroy(this.gameObject);
    }
}
