using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // ← plusieurs ennemis
    public Camera cam;
    public float offsetAboveScreen = 1f;

    public GameObject SpawnEnemy()
    {
        if (enemyPrefabs.Length == 0)
        {
            Debug.LogError("Aucun prefab ennemi assigné au EnemySpawner !");
            return null;
        }

        // choisir un prefab au hasard
        GameObject selectedPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        // choisir position random en haut de l'écran
        float randomX = Random.Range(0f, 1f);
        Vector3 spawnPos = cam.ViewportToWorldPoint(
            new Vector3(randomX, 1f, -cam.transform.position.z)
        );
        spawnPos.y += offsetAboveScreen;
        spawnPos.z = 0;

        // spawn l'ennemi random
        return Instantiate(selectedPrefab, spawnPos, Quaternion.identity);
    }
}
