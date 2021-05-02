using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrom : Damage
{
    private int lives = 3;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Tegelaanius.Instance.gameObject)
        {
            Tegelaanius.Instance.GetDamage();
            lives--;

        }

        if (lives < 1)
        {
            Die();
        }
    }

}
