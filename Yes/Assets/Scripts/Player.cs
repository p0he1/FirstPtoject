using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public float speed;
    public float JumpForce;
    public float bonGravity;

    public bool isGrounded;
    public bool ICDDJ;
    public bool LS;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb2d;
    private Animator animator;

    private float yPositionLF;

    public int coins;
    public Text coinsText;

    public float health;
    public float healthMax;
    public Image healthImage;
    public Text healthText;

    public float Stamina;
    public float StaminaMax;
    public Image StaminaImage;
    public Text StaminaText;
    public bool staminaBool;
    public bool staminaReg;

    public GameObject bulletPrefab;
    public float bulletForce;
    public bool flippX;

    public int scene;
    public GameObject pauseMenu;

    public bool gunTrigger;

    public GameObject dieMenu;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        coinsText.text = coins.ToString();
    }
    private void FixedUpdate()
    {
        Vector3 currentPosition = transform.position;

        if(Input.GetKey(KeyCode.LeftShift) && staminaBool)
        {
            LS = true;
            Stamina -= 0.3f;
        }
        else
        {
            LS = false;
            Stamina += 0.2f;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            Stamina -= 0.2f;

            if (LS)
            {
                speed = 0.14f;
            }
            else
            {
                speed = 0.07f;
            }
            if (Input.GetKey(KeyCode.A))
            {
                currentPosition.x -= speed;
                spriteRenderer.flipX = true;
                flippX = true;
            }
            else if (Input.GetKey(KeyCode.D)) 
            {
                currentPosition.x += speed;
                spriteRenderer.flipX = false;
                flippX = false;
            }
            if (isGrounded)
            {
                if (LS && gunTrigger)
                {
                    animator.Play("FRWG");
                }
                else if(gunTrigger)
                {
                    animator.Play("RWG");
                }
                else if (LS)
                {
                    animator.Play("Fasterun");
                }
                else
                {
                    animator.Play("Run");
                }
            }
            else if (gunTrigger)
            {
                animator.Play("JWG");
            }
            else 
            {
                animator.Play("Jump");
            }
        }
        else 
        {
            if (isGrounded && gunTrigger)
            {
                animator.Play("IWG");
                Stamina += 0.2f;
            }
            else if (!isGrounded && gunTrigger)
            {
                animator.Play("JWG");
            }
            else if (isGrounded && !gunTrigger)
            {
                animator.Play("idle");
                Stamina += 0.2f;
            }
            else if (!isGrounded && !gunTrigger)
            {
                animator.Play("Jump");
            }
        }


        transform.position = currentPosition;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Stamina >= 10)
        {
            if(isGrounded || ICDDJ)
            {
                Stamina -= 10;

                rb2d.AddForce(transform.up * JumpForce, ForceMode2D.Impulse);
                if (ICDDJ && !isGrounded)
                {
                   ICDDJ = false;
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.Mouse0) && gunTrigger)
        {
            GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity, null);

            if(flippX)
            {
                newBullet.transform.position = newBullet.transform.position + -transform.right/2 + transform.up/4.6f;
                newBullet.GetComponent<Rigidbody2D>().AddForce(-transform.right * bulletForce, ForceMode2D.Impulse);
            }
            else if(!flippX)
            {
                newBullet.transform.position = newBullet.transform.position + transform.right/2 + transform.up/4.6f;
                newBullet.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
            }

            Destroy(newBullet, 5);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }

        if (yPositionLF > transform.position.y)
        {
            rb2d.AddForce(-transform.up * bonGravity, ForceMode2D.Force);
        }
    }

    private void LateUpdate()
    {
        if (transform.position.y <= -8)
        {
            dieMenu.SetActive(true);
        }

        health = Mathf.Clamp(health, 0, healthMax);

        healthImage.fillAmount = health / healthMax;

        healthText.text = health.ToString();

        if (health == 0)
        {
            dieMenu.SetActive(true);
        }

        Stamina = Mathf.Clamp(Stamina, 0, StaminaMax);

        StaminaImage.fillAmount = Stamina / StaminaMax;

        StaminaText.text = Mathf.CeilToInt(Stamina).ToString();

        if(Stamina <= 20)
        {
            staminaBool = false;
        }
        else
        {
            staminaBool = true;
        }

        yPositionLF = transform.position.y;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Platforma")
        {
            isGrounded = true;
            ICDDJ = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Platforma")
        {
            isGrounded = false;
        }
    }
}
