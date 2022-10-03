using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem particles;
    [SerializeField] float range = 15f;

    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        particles = GetComponentInChildren<ParticleSystem>();
        FindClosestTarget();
    }

    // Update is called once per frame
    void Update()
    {
        AimWeapon();
    }

    void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        GameObject closestTarget = null;
        float maxDistance = range;

        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if(targetDistance < maxDistance)
            {
                closestTarget = enemy.gameObject;
                maxDistance = targetDistance;
            }
        } 
        target = closestTarget;
    }
    void AimWeapon()
    {
        if (target != null)
        {
            weapon.LookAt(target.transform.position);

            if (Vector3.Distance(transform.position, target.transform.position) < range && target.activeInHierarchy)
            {
                Attack(true);
                return;
            }
        }
        Attack(false);
        FindClosestTarget();
        
    }

    void Attack(bool doAttack)
    {
        var emissionModule = particles.emission;
        emissionModule.enabled = doAttack;

    }
}
