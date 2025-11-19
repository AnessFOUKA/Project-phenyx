using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Points que rapporte la destruction de cet ennemi
    public int scoreValue = 100;
    
    // Référence au GameManager pour mettre à jour le score
    private GameManager gameManager;

    void Start()
    {
        // Tente de trouver le GameManager dans la scène au démarrage.
        // Assurez-vous d'avoir un objet avec le script GameManager attaché.
        gameManager = FindObjectOfType<GameManager>();

        if (gameManager == null)
        {
            Debug.LogError("GameManager non trouvé dans la scène. Le score ne sera pas mis à jour.");
        }
    }

    // Fonction appelée lorsqu'un autre Collider entre dans le Collider Trigger de cet ennemi
    void OnTriggerEnter2D(Collider2D other)
    {
        // 1. On vérifie si l'objet qui nous a touché est le projectile spécial
        //    (en regardant s'il a le composant SpecialProjectileScript)
        if (other.GetComponent<SpecialProjectileScript>() != null)
        {
            // 2. Si c'est le cas, on appelle la fonction pour gérer la destruction et le score
            HandleHit();
            
            // 3. On détruit le projectile après l'impact (pour ne pas qu'il traverse tout)
            Destroy(other.gameObject); 
        }
    }

    private void HandleHit()
    {
        // Si le GameManager existe, on ajoute le score
        if (gameManager != null)
        {
            gameManager.AddScore(scoreValue); 
            // Vous pouvez ajouter ici d'autres actions (sons, effets visuels d'explosion, etc.)
        }
        
        // Finalement, on détruit l'ennemi
        Destroy(gameObject); 
    }
}
