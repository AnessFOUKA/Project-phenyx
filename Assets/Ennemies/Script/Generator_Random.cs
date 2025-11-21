using UnityEngine;

public class Generator_Random : MonoBehaviour
{
    [Header("General Settings")]
    public ShootType shootType = ShootType.Random;
    public GameObject bulletPrefab;

    [Header("Fire Rates per Type")]
    public float straightFireRate = 0.3f;
    public float sprayFireRate = 0.5f;
    public float circleFireRate = 1.5f; // plus lent
    public float spiralFireRate = 0.1f;

    private float timer;

    [Header("Spray Settings")]
    public int sprayCount = 5;
    public float sprayAngle = 45f;

    [Header("Circle Settings")]
    public int circleBullets = 20;

    [Header("Spiral Settings")]
    public float spiralSpeed = 90f; // degré / seconde
    private float spiralAngle;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        // Choix aléatoire du mode
        if (shootType == ShootType.Random)
        {
            shootType = (ShootType)Random.Range(0, 5); // Straight à Wave
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        float currentFireRate = GetFireRate();

        if (timer >= currentFireRate)
        {
            Shoot();
            timer = 0f;
        }
    }

    float GetFireRate()
    {
        switch (shootType)
        {
            case ShootType.Straight:
                return straightFireRate;
            case ShootType.Spray:
                return sprayFireRate;
            case ShootType.Circle:
                return circleFireRate;
            case ShootType.Spiral:
                return spiralFireRate;
            default:
                return 0.3f;
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
            case ShootType.Circle:
                ShootCircle();
                break;
            case ShootType.Spiral:
                ShootSpiral();
                break;
        }
    }

    // ------------------- SHOOT METHODS ---------------------

    void ShootStraight()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }

    void ShootSpray()
    {
        float halfAngle = sprayAngle / 2f;
        for (int i = 0; i < sprayCount; i++)
        {
            float angleStep = (sprayCount == 1) ? 0 : sprayAngle / (sprayCount - 1);
            float angle = -halfAngle + angleStep * i;

            Quaternion rot = transform.rotation * Quaternion.Euler(0, 0, angle);
            Instantiate(bulletPrefab, transform.position, rot);
        }
    }

    void ShootCircle()
    {
        float angleStep = 360f / circleBullets;

        for (int i = 0; i < circleBullets; i++)
        {
            Quaternion rot = Quaternion.Euler(0, 0, i * angleStep);
            Instantiate(bulletPrefab, transform.position, rot);
        }
    }

    void ShootSpiral()
    {
        spiralAngle += spiralSpeed * Time.deltaTime;
        Quaternion rot = Quaternion.Euler(0, 0, spiralAngle);
        Instantiate(bulletPrefab, transform.position, rot);
    }
}
