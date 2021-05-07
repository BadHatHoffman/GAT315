using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayer;

    public float attackRange = 0.5f;
    public int attackDamage = 50;

    public float attackRate = 2.0f;
    float nextAttack = 0f;

    void Update()
    {
        if(Time.time >= nextAttack)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                nextAttack = Time.time + 1.0f / attackRate;
            }
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmos()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
