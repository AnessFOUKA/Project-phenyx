using UnityEditor.UI;
using UnityEngine;

public class Generator_Base : MonoBehaviour
{
    [Header("General Settings")]
    public ShootType shootType;
    public GameObject bulletPrefab;
    public float fireRate = 0.3f;
    private float timer;

    [Header("Spray Settings")]
    public int sprayCount = 5;          // number of bullets in the fan
    public float sprayAngle = 45f;      // total angle

    [Header("Follow Settings")]
    private GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Debug.LogWarning("Aucun objet avec le tag 'Player' trouvé !");
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= fireRate)
        {
            Shoot();
            timer = 0f;
        }
    }

    void Shoot()
    {
        switch (shootType)
        {
            case ShootType.Straight:
                ShootStraight();
                break;

            case ShootType.Spray:
                ShootSpray();
                break;
        }
    }

    void ShootStraight()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }

    void ShootSpray()
    {
        float halfAngle = sprayAngle / 2f;

        for (int i = 0; i < sprayCount; i++)
        {
            // rotation relative à l’objet
            float angleStep = (sprayCount == 1) ? 0 : sprayAngle / (sprayCount - 1);
            float angle = -halfAngle + angleStep * i;

            Quaternion rot = transform.rotation * Quaternion.Euler(0, 0, angle);
            Instantiate(bulletPrefab, transform.position, rot);
        }
    }

    void ShootFollow()
    {
        
        if (player == null) return;

        // rotation de l’objet vers le joueur
        Vector3 direction = player.transform.position - transform.position;
        transform.up = -direction;

        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }

}
