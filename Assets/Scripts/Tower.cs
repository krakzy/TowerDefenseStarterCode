using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float attackRange = 1f; // Range within which the tower can detect and attack enemies
    public float attackRate = 1f; // How often the tower attacks (attacks per second)
    public int attackDamage = 1; // How much damage each attack does
    public float attackSize = 1f; // How big the bullet looks
    public GameObject bulletPrefab; // The bullet prefab the tower will shoot
    public TowerType type; // the type of this tower

    private float nextAttackTime;

    // Draw the attack range in the editor for easier debugging
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            // Find all enemies within range
            Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, attackRange);
            foreach (Collider2D enemyCollider in enemies)
            {
                if (enemyCollider.CompareTag("Enemy"))
                {
                    // Create bullet and set its properties
                    GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                    Projectile projectile = bullet.GetComponent<Projectile>();
                    projectile.damage = attackDamage;
                    projectile.target = enemyCollider.transform;
                    bullet.transform.localScale = new Vector3(attackSize, attackSize, 1);

                    // Set next attack time
                    nextAttackTime = Time.time + 1f / attackRate;
                    break; // Only shoot one enemy per attack
                }
            }
        }
    }
}

