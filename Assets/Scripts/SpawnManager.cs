using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Enemy[] enemyPrefabs;
    [SerializeField] float initialDirection;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Spawn random enemies from the enemyPrefabs array. Direction is determined by the initialDirection variable
    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 2.5f));
            int randomIndex = Random.Range(0, enemyPrefabs.Length);
            Enemy newEnemy = Instantiate(enemyPrefabs[randomIndex], transform.position, transform.rotation);
            newEnemy.direction = initialDirection;
        }
    }
}
