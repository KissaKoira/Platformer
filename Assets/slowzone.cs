using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowzone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<player_controller>() != null)
        {
            collision.gameObject.GetComponent<player_controller>().slow(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<player_controller>() != null)
        {
            collision.gameObject.GetComponent<player_controller>().slow(false);
        }
    }
}
