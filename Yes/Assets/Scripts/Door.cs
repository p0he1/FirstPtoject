using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private Animator doorAni;
    public bool oopen;
    public int scene;

    private void Start()
    {
        doorAni = GetComponent<Animator>();
    }
    private void Update()
    {
        if(oopen)
        {
            doorAni.Play("open");
        }
        else
        {
            doorAni.Play("close");
        }
        if (Input.GetKeyDown(KeyCode.E) && oopen)
        {
            SceneManager.LoadScene(scene);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            oopen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            oopen = false;
        }
    }
}
