using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TowerDefense.Agents;

public class NewEnemyDetection : MonoBehaviour
{
    [SerializeField]
    private int health;
    [SerializeField]
    private int damage;
    [SerializeField]
    private GameObject projectilePrefab;
    [SerializeField]
    private float bulletTimer;
    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    private NavMeshAgent navMesh;
    [SerializeField]
    private Transform endPoint;
    protected bool isAttacking;

    public GameObject spawnpoint;

    private void Awake() {
        navMesh.SetDestination(GameObject.Find("HeadQuarters").transform.position);
    }
    private void OnTriggerEnter(Collider other) {
        Debug.Log(other);
        if (other.gameObject.name == "End")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Bullet")
        {
            TakeDamage(damage);
        }
        
    }
    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            Vector3 playerPos = other.gameObject.transform.position;
            //TurnTurret();
            if (!isAttacking)
            {
               StartCoroutine(Attack(playerPos));
            }
        }
    }
    public void TakeDamage(int taken){
        health-=taken;
        Debug.Log("Damage taken:" + taken);
        Debug.Log("Health: "+health);
        if (health<=0)
        {
            Destroy(gameObject);
        }
    }
    private IEnumerator Attack(Vector3 pos){
        isAttacking=true;
        Debug.Log("Attacking");   
        GameObject prefab = Instantiate(projectilePrefab, gameObject.transform.position, Quaternion.identity);
        Debug.Log(prefab.transform.position);
        prefab.transform.LookAt(pos);
        yield return new WaitForSeconds(bulletTimer);
        isAttacking=false;
        yield return null;
    }
}
