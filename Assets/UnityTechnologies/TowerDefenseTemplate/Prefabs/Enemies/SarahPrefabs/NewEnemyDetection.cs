using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NewEnemyDetection : MonoBehaviour
{


    public GameObject projectilePrefab;
    public float bulletTimer;
    public float bulletSpeed;

    public NavMeshAgent navMesh;

    public Transform endPoint;
    public bool isAttacking;
    // Start is called before the first frame update

    //don't need to make a list since there is only 1 player at a time

    private void Awake() {
        navMesh.SetDestination(endPoint.position);
    }
    private void OnTriggerEnter(Collider other) {
        Debug.Log(other);
        if (other.gameObject.name == "End")
        {
            Destroy(gameObject);
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
    IEnumerator Attack(Vector3 pos){
        isAttacking=true;
        Debug.Log("Attacking");   
        GameObject prefab = Instantiate(projectilePrefab, gameObject.transform.position, Quaternion.identity);
        prefab.transform.LookAt(pos);
        yield return new WaitForSeconds(bulletTimer);
        isAttacking=false;
        yield return null;
    }
}
