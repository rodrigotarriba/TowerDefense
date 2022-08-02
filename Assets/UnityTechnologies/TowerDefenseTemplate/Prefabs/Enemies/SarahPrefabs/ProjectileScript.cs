using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField]
    private float despawnTimer;
    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject explosion;

    [SerializeField]
    private Rigidbody rb;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);
        rb.AddForce(Vector3.forward*speed*Time.deltaTime);
        despawnTimer-=Time.deltaTime;
        if (despawnTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
