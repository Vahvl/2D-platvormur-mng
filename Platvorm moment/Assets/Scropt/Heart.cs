using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Tegelaanius character = collision.GetComponent<Tegelaanius>();

        if (character)
        {
            character.Lives++;
            Destroy(gameObject);
        }
    }
}

