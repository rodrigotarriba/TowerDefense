using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{

    public GameObject endPoint;
    public NavMeshAgent navMeshAgent;


    //This can be redone with a scriptable object, just want something working first.
    public int Health;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(endPoint.transform.position);

    }

    // Update is called once per frame
    public void Damaged(int damage){
        Health-=damage;
        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Endpoint")
        {
            Destroy(gameObject);
        }
    }
}
