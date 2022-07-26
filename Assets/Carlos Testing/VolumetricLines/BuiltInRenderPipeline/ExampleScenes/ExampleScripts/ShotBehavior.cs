﻿using UnityEngine;
using System.Collections;
using TowerDefense.Level;
using Core.Health;
using ActionGameFramework.Health;

public class ShotBehavior : MonoBehaviour 
{
    public Vector3 m_target;
    public GameObject collisionExplosion;
    public float speed;
    [SerializeField] private LayerMask whatAreEnemies;
    public int damageDealt;

    public Damager damager;


    
    void Update()
    {
        // transform.position += transform.forward * Time.deltaTime * 300f;// The step size is equal to speed times frame time.
        float step = speed * Time.deltaTime;

        if (m_target != null)
        {
            if (transform.position == m_target)
            {
                explode();
                return;
            }
            transform.position = Vector3.MoveTowards(transform.position, m_target, step);
        }

    }

    public void setTarget(Vector3 target)
    {
        m_target = target;
    }

    void explode()
    {
        
        if (collisionExplosion != null)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 1.5f, whatAreEnemies);
            
            foreach(Collider c in colliders)
            {
                if (c.GetComponent<Transform>())
                {
                    Debug.Log(c.name);
                    if (c.GetComponent<NewEnemyDetection>())
                    {
                        c.GetComponent<NewEnemyDetection>().TakeDamage(damageDealt);
                    }
                    c.gameObject.GetComponent<DamageableBehaviour>().TakeDamage(damager.damage, c.gameObject.transform.position, damager.alignmentProvider);
                }
            }

            GameObject explosion = (GameObject)Instantiate(
                collisionExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(explosion, 1f);
        }


    }

    
}
