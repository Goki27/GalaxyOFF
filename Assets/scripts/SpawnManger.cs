using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManger : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyShip;
    [SerializeField]
    private GameObject[] PowerUps;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawn());
        StartCoroutine(powerSpawnRandom());
    }

    IEnumerator EnemySpawn()
    {
        while (true)
        {
            Instantiate(enemyShip, new Vector3(Random.Range(-7f, 7f), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(3.0f);
        }
    }
    IEnumerator powerSpawnRandom()
    {
        while (true) {
            int randomPower = Random.Range(0, 2);
            Instantiate(PowerUps[randomPower],new Vector3(Random.Range(-7, 7), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(3);
        } 
    }
}
