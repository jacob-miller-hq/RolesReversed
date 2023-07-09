using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject path;
    public GameObject hoard;

    public float minSpawnTime = 0.5f;
    public float baselineSpawnTime = 3f;
    public float jostleTime = 0.5f;
    public float baselineSpeed = 0.02f;
    public int baselineDamage = 2;
    public float baselineAttackSpeed = 2f;

    float lastSpawn = 0;
    float timeTillNext;

    // Start is called before the first frame update
    void Start()
    {
        spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastSpawn > timeTillNext)
        {
            spawn();
        }
    }

    void spawn()
    {
        lastSpawn = Time.time;
        int goldAmt = hoard.GetComponentInChildren<PileOfGold>().amount;
        timeTillNext = minSpawnTime + ((Random.value - 0.5f) * 2f * jostleTime) + (baselineSpawnTime / Mathf.Pow(goldAmt + 1, 0.1f));
        GameObject newEnemy = Instantiate(enemyPrefab);
        newEnemy.transform.position = transform.position;

        EnemyController controller = newEnemy.GetComponent<EnemyController>();
        controller.path = path;
        controller.speed = baselineSpeed + (Mathf.Sqrt(goldAmt) / 200) + (Random.value / 100);
        controller.hoard = hoard;
        
        DamageTag sword = newEnemy.GetComponentInChildren<DamageTag>();
        sword.damageAmt = baselineDamage + (goldAmt / 50);
        sword.timePerHit = baselineAttackSpeed - (goldAmt / 100);
    }
}
