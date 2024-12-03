using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator anim;
    private bool isDead = false;
    public Transform player;
    private float delay = 3;
    private int vida = 2;
    public Level1Activate ContardorEnemies;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        

    }


    void Update()
    {
        if (isDead == false)
        {
            SetDestination(player.position);
        }
    }

    public void SetDestination(Vector3 newdestination)
    {
        agent.destination = newdestination;

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            vida--;

            if (vida <= 0)
            {
                anim.SetBool("Muelto", true);
                TriggerDeath();
            }
        }



    }
    private IEnumerator Muelto(float delay)
    {
        
        yield return new WaitForSeconds(delay);
        ContardorEnemies.EnemyDefeated();
        Destroy(gameObject);
    }
    private void TriggerDeath()
    {
        
        agent.enabled = false;
        isDead = true;
        

        
        

        StartCoroutine(Muelto(delay));
    }

   
}
