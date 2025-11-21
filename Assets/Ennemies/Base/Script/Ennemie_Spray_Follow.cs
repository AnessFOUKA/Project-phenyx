using UnityEngine;

public class Ennemie_Spray_Follow : Enemie_Base
{
    private GameObject player;

    [Header("Rotation Settings")]
    public float rotationSpeed = 5f; // plus c'est grand, plus ça tourne vite

    protected override void Start()
    {
        base.Start();
        // récupère le joueur au début
        player = GameObject.FindGameObjectWithTag("Player");
    }

    protected override void Move()
    {
        FollowPlayerRotation();
    }

    private void FollowPlayerRotation()
    {
        if (player == null) return;

        // direction vers le joueur
        Vector3 direction = player.transform.position - transform.position;

        // rotation cible pour que le haut du sprite pointe vers le joueur
        Quaternion targetRotation = Quaternion.FromToRotation(Vector3.up, -direction);

        // interpolation de la rotation pour que ce soit plus doux
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
