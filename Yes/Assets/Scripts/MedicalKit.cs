using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicalKit : MonoBehaviour
{
    public Player player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.health += 20;
            Destroy(gameObject);
        }
    }
}
