using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{

    public float damage;
    public float impulse;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Player>())
        {
            collision.gameObject.GetComponent<Player>().health -= damage;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(collision.transform.up * impulse, ForceMode2D.Impulse);
        }
    }
}
