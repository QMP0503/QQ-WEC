using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy enemyPrefab;
    public float spawnRate = 2.0f;
    public int spawnAmount = 1;
    public float spawnDistance = 12.0f;
    public float size = 5;

    public float trajectoryVariance = 15.0f;


    private void Start()
    {
        InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);
    }

    private void Spawn()
    {
        for (int i = 0; i < this.spawnAmount; i++)
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * spawnDistance;
            Vector3 spawnPoint = this.transform.position + spawnDirection;

            float variance = Random.Range(-this.trajectoryVariance, this.trajectoryVariance);

            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            Enemy enemy = Instantiate(this.enemyPrefab, spawnPoint, rotation);

            enemy.transform.localScale = new Vector3(size, size, 1);


        }

    }
}
