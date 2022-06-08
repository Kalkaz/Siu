using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    public Transform player;
    PlayerC playerstats;
    public float stopingDistance;
    public float retreatDistance;
    public float followDistance;
    public float speed=10f;
    public int zombieHealth = 20;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerC>().transform;
        playerstats = GameObject.Find("Player").GetComponent<PlayerC>();
    }

    
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) > stopingDistance && Vector3.Distance(transform.position, player.position) < followDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            transform.LookAt(player);
        }
        else if (Vector3.Distance(transform.position, player.position) < stopingDistance &&
                 Vector3.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
            transform.LookAt(player);
        }
        else if (Vector3.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            transform.LookAt(player);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            //playerstats.playerHealth -= 5;
            playerstats.setText();
            transform.position = Vector3.MoveTowards(transform.position, player.position, -speed*0.5f );
        }
    }


}
