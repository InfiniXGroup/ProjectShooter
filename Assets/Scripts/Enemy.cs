using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform target;
    [SerializeField] Animator animator;


    //Customize
    [SerializeField] int nbGold;
    [SerializeField] public float maxHealth; //In base maxHealth = 100f;
    
    private float currentHealth;

    private bool canAttack;


    void Start()
    {
        currentHealth = maxHealth;
        canAttack = true;
    }


    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0f)
        {
            animator.SetBool("isAlive", false);
            StartCoroutine(DelayedDie(2f));
        }
    }
    IEnumerator DelayedDie(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        Die();
    }

    void Die()
    {
        PointScoreManager.instance.modifyScore(nbGold);
        Destroy(gameObject);
    }
    
    void Update()
    {

        if (LifePlayer.instance.GameOverUI.activeInHierarchy == false)
        {
            float sqrLen = (target.position - transform.position).sqrMagnitude;
            if (sqrLen >= 2f)
            {
                animator.SetBool("isAttack", false);
                if (sqrLen < 50f)
                {
                    agent.SetDestination(target.position);
                    animator.SetBool("isRunning", true);
                }
                else
                    animator.SetBool("isRunning", false);
            }
            else
            {
                if(canAttack == true)
                {
                    animator.SetBool("isAttack", true);
                    LifePlayer.instance.LoseLife(1);
                    canAttack = false;
                }       
            }
        }

    }
    IEnumerator DelayedCooldown(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        canAttack = true;
    }

}
