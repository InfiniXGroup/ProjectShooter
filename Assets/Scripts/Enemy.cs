using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform target;
    [SerializeField] Animator animator;

    [SerializeField] GameObject gameover;

    //Customize
    [SerializeField] int nbGold;
    [SerializeField] public float maxHealth; //In base maxHealth = 100f;
    
    private float currentHealth;

    private bool isAttackAnimationPlaying = false;

    public static Enemy instance; 

    void Start()
    {
        currentHealth = maxHealth;
    }
    private void Awake()
    {
        instance = this; 
        PointScoreManager.instance = FindObjectOfType<PointScoreManager>();
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

        if (gameover.activeInHierarchy == false)
        {
            float sqrLen = (target.position - transform.position).sqrMagnitude;
            if (sqrLen >= 1f)
            {
                animator.SetBool("isAttack", false);
                if (sqrLen < 20)
                {
                    agent.SetDestination(target.position);
                    animator.SetBool("isRunning", true);
                }
                else
                    animator.SetBool("isRunning", false);
            }
            else
            {
                if (!isAttackAnimationPlaying)
                {
                    animator.SetBool("isAttack", true);
                    //life player down
                    isAttackAnimationPlaying = true;
                }        
            }
        }

    }

    public void AttackAnimationFinished()
    {
        isAttackAnimationPlaying = false;
    }
}
