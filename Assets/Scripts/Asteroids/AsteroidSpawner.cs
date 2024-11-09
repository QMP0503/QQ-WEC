using System.Collections;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public Asteroid asteroidPrefab; // Asteroid prefab to spawn
    public float initialSpawnRate = 3f; // Initial spawn rate (in seconds per spawn)
    public float maxSpawnRate = 0.2f; // Maximum spawn rate (in seconds per spawn)
    public float timeToMaxRate = 300f; // Time (in seconds) to reach max spawn rate

    public int spawnAmount = 1; // Number of asteroids to spawn at a time
    public float spawnDistance = 12.0f; // Distance from spawner to spawn asteroids
    public float trajectoryVariance = 15.0f; // Variance in the asteroid's initial trajectory

    private float spawnRate; // Current spawn rate
    private float elapsedTime = 0f; // Elapsed time counter for rate adjustment

    private void Start()
    {
        spawnRate = initialSpawnRate;
        StartCoroutine(SpawnAsteroids());
    }

    private IEnumerator SpawnAsteroids()
    {
        while (true)
        {
            // Spawn the asteroids
            Spawn();

            // Wait for the current spawn rate before spawning the next set
            yield return new WaitForSeconds(spawnRate);

            // Increase elapsed time by the spawn interval
            elapsedTime += spawnRate;

            // Calculate the new spawn rate, gradually decreasing towards maxSpawnRate
            spawnRate = Mathf.Lerp(initialSpawnRate, maxSpawnRate, elapsedTime / timeToMaxRate);

            // Clamp spawn rate to the maximum rate to avoid going below it
            spawnRate = Mathf.Max(spawnRate, maxSpawnRate);
        }
    }

    private void Spawn()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * spawnDistance;
            Vector3 spawnPoint = transform.position + spawnDirection;

            float variance = Random.Range(-trajectoryVariance, trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            // Instantiate the asteroid with the specified position and rotation
            Asteroid asteroid = Instantiate(asteroidPrefab, spawnPoint, rotation);

            // Set the asteroid's size and trajectory
            asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize);
            asteroid.SetTrajectory(rotation * -spawnDirection);
        }
    }
}
