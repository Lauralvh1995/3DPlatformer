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
        if (target != null && homing)
        {
            meshAgent.speed = 10 * speed;
            meshAgent.SetDestination(target);
        }
        Damage += GameManager.instance.player.GetDamageBonus(damageType);
    }
    private void Update()
    {
        if (!homing)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, 10f * speed * Time.deltaTime);
        }
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            if (projectileType == ProjectileType.Ball)
            {
                Explode();
            }
            else
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
        Debug.Log(enemies);
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
