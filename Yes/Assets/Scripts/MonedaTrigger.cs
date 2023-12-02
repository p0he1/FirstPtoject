using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonedaTrigger : MonoBehaviour
{
    public Animator animSunduk;

    public bool one;
    public enum Coins
    {
        coin,
        sunduk
    }
    public Coins coins;

    private void Start()
    {
        one = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (coins == Coins.coin)
        {
            if (collision.tag == "Player")
            {
                Player player = collision.GetComponent<Player>();

                player.coins++;
                player.coinsText.text = player.coins.ToString();

                Destroy(gameObject);
            }
        }
        else if (coins == Coins.sunduk)
        {
            if (collision.gameObject.tag =="Player" && one)
            {
                Player player = collision.GetComponent<Player>();

                player.coins += 10;
                player.coinsText.text = player.coins.ToString();

                animSunduk.Play("Spizdulu");
                one = false;
            }
        }
    }
}
