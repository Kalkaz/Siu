using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PlayerC : MonoBehaviour
{
    float sensitivity = 150f;
    public Transform player;
    float xR = 0f;
    float yR = 0f;
    public CharacterController controller;
    float speed = 15f;
    Vector3 velocity;
    float gravity = -1.81f;
    public Transform ground;
    float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public int playerHealth = 100;
    public int ammo2 = 20;
    public GameObject bullet;
    public Transform rightBarrel;
    public Transform leftBarrel;
    private float nextFire = 0.0f;
    public static float fireRate = 0.6f;
    public int coin = 0;
    public int exp = 0;
    public int lvl = 0;
    public int prelvl = 0;
    public TextMeshProUGUI cointext, exptxt, lvltxt, healthtxt, ammo2txt;
    public Button restoreHealth;
    public Button restoreAmmo;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cointext.text = 0.ToString();
        exptxt.text = 0.ToString();
        lvltxt.text = 0.ToString();
        healthtxt.text = 100.ToString();
        ammo2txt.text = 20.ToString();
        restoreHealth.onClick.AddListener(RestoreHealth);
        restoreAmmo.onClick.AddListener(RestoreAmmo);
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(ground.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y -= 2f;
        }

        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        xR -= mouseY;
        yR += mouseX;
        xR = Mathf.Clamp(xR, -90f, 90f);
        player.Rotate(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(xR, yR, 0);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        
        if (playerHealth<=0)
        {
            SceneManager.LoadScene("DeathScene");
        }

        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {
            ammo2 -= 2;
            ammo2txt.text = ammo2.ToString();
            Instantiate(bullet, rightBarrel.position, rightBarrel.rotation);
            Instantiate(bullet, leftBarrel.position, leftBarrel.rotation);
            nextFire = Time.time + fireRate;
            
        }

        if (exp>=100)
        {
            lvl = exp / 100;
            
            if (lvl>prelvl)
            {
                lvltxt.text = lvl.ToString();
                prelvl = lvl;

            }
        }


    }
    public void setText()
    {
        cointext.text = coin.ToString();
        exptxt.text = exp.ToString();
        healthtxt.text = playerHealth.ToString();
    }

    public void RestoreHealth()
    {
        if (coin>=100)
        {
            playerHealth = 100;
            healthtxt.text = playerHealth.ToString();
            coin -= 100;
            cointext.text = coin.ToString();
        }
    }

    public void RestoreAmmo()
    {
        if (coin>=50)
        {
            ammo2 = 20;
            ammo2txt.text = ammo2.ToString();
            coin -= 50;
            cointext.text = coin.ToString();
        }
    }
}