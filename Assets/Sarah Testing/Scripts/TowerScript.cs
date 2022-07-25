using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    public List<EnemyBehavior> enemiesInRange = new List<EnemyBehavior>();

    //can be done with scriptable object
    public float cooldown;
    public int damage;
    public float lineVisible;
    public LineRenderer towerRenderer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AttackEnemiesInRange());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        //if enemy comes into tower's radius
        Debug.Log(other.gameObject.name);
        EnemyBehavior enemy = other.GetComponent<EnemyBehavior>();
        if (enemy != null)
        {
            enemiesInRange.Add(enemy);
        }
    }

    private void OnTriggerExit(Collider other) {
        //if enemy leaves
        EnemyBehavior enemy = other.GetComponent<EnemyBehavior>();
        if (enemy != null)
        {
            enemiesInRange.Remove(enemy);
        }
    }

    private IEnumerator AttackEnemiesInRange(){
        while (true)
        {
            enemiesInRange.RemoveAll(x => x == null);
            if (enemiesInRange.Count > 0)
            {
                EnemyBehavior enemy = enemiesInRange[0];
                //attack enemy
                StartCoroutine(ShootEnemy(enemy));
            }
            //find enemy
            
            
            
            //wait for cooldown

            yield return new WaitForSeconds(cooldown);
        }
    }

    private void ClearLineRender(){
        towerRenderer.gameObject.SetActive(false);
    }

    private IEnumerator ShootEnemy(EnemyBehavior enemy)
    {
        Debug.Log("shooting");
        towerRenderer.gameObject.SetActive(true);
        towerRenderer.SetPosition(0, this.transform.position);
        towerRenderer.SetPosition(1, enemy.transform.position);
        enemy.Damaged(damage);
        yield return new WaitForSeconds(lineVisible);
        ClearLineRender();
    }
}
