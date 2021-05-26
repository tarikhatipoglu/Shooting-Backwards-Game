using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player;
    public int life;

    void Start()
    {
        life = 3;
    }


    void Update()
    {
        enemy.SetDestination(player.position);
        if(life <= 0 || life == 0)
        {
            life = 0;
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter(Collision enemyCollider)
    {
        if(enemyCollider.gameObject.tag == "Bullet")
        {
            life--;
            Destroy(enemyCollider.gameObject);
        }
    }
}
