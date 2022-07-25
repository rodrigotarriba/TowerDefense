using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float enemySpawnTime;
    public GameObject spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator SpawnEnemy(){
        while (true)
        {
            Instantiate(enemyPrefab, spawnPoint.transform);
            yield return new WaitForSeconds(enemySpawnTime);
        }
        
    }
}
