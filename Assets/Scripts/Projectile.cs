using Assets.Scripts;
using Assets.Scripts.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Projectile : MonoBehaviour
{
    public DamageType damageType;
    public ProjectileType projectileType;
    public int Damage;
    public int speed;
    public float radius;
    public bool homing;
    public LayerMask enemyMask;
    public LayerMask groundMask;

    public NavMeshAgent meshAgent;
    public Vector3 target;
    public void Start()
    {
        if (target != null)
        {
            meshAgent.SetDestination(target);
        }
        Damage += GameManager.instance.player.getBonus(damageType);
    }
    private void Update()
    {
        if (!homing)
        {
            if (projectileType == ProjectileType.Ball)
            {
                transform.Translate(target * Time.deltaTime * speed, Space.World);
                if(transform.position == target)
                {
                    Explode();
                }

            }
            if (projectileType == ProjectileType.Bolt)
            {
                transform.Translate(target * Time.deltaTime * speed, Space.World);
            }
        }
        else if(meshAgent.remainingDistance < 0.5f)
        {
            if (projectileType == ProjectileType.Ball)
            {
                Explode();
            }
            if (projectileType == ProjectileType.Bolt)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == enemyMask || other.gameObject.layer == groundMask)
        {
            if (projectileType == ProjectileType.Ball)
            {
                Explode();
            }
            if(projectileType == ProjectileType.Bolt)
            {
                if(other.gameObject.layer == enemyMask)
                {
                    other.GetComponent<Enemy>().TakeDamage(Damage);
                }
                Destroy(gameObject);
            }
        }
    }
    void Explode()
    {
        //Explode on impact
        Collider[] enemies = Physics.OverlapSphere(transform.position, radius, enemyMask);
        foreach (Collider enemy in enemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(2 * Damage / enemies.Length);
        }
        Destroy(gameObject);
    }
}
public enum ProjectileType
{
    Bolt,
    Ball,
}
