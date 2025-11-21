using UnityEngine;

public class GameController : MonoBehaviour
{
    public EnemySpawner spawner;

    private int currentWave = 0;
    private bool waveInProgress = false;

    private void Start()
    {
        StartNextWave();
    }

    private void Update()
    {
        if (waveInProgress)
        {
            // check s'il reste des ennemis
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Ennemie");

            if (enemies.Length == 0)
            {
                waveInProgress = false;
                StartNextWave();
            }
        }
    }

    void StartNextWave()
    {
        currentWave++;

        StartWave(currentWave*2);

    }

    void StartWave(int enemyCount)
    {
        waveInProgress = true;

        for (int i = 0; i < enemyCount; i++)
            spawner.SpawnEnemy();
    }

}
