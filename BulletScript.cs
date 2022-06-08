using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletScript : MonoBehaviour
{
    PlayerC playerStats;

    void Start()
    {
        Destroy(gameObject, 2.5f);
        playerStats = GameObject.Find("Player").GetComponent<PlayerC>();
    }

    void Update()
    {
        transform.Translate(-Vector3.forward * 100 * Time.deltaTime);
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="zombie")
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<ZombieScript>().zombieHealth -= 10;

            if (collision.gameObject.GetComponent<ZombieScript>().zombieHealth==0)
            {
                Destroy(collision.gameObject);
                playerStats.exp += 10;
                playerStats.coin += 10;
                playerStats.setText();
            }
        }
    }
}
