using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossKill : MonoBehaviour
{
    public KladScript KS;

    public int healthBoss = 20;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            healthBoss -= 1;
            Destroy(collision.gameObject);

            if (healthBoss == 0)
            {
                KS.kladPlatform = true;
                Destroy(gameObject);
            }
        }
    }
}
