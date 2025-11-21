using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int scoreValue = 100;
    
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

    }

    // Fonction appelée lorsqu'un autre Collider entre dans le Collider Trigger de cet ennemi
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.GetComponent<SpecialProjectileScript>() != null)
        {
            HandleHit();
            
            Destroy(other.gameObject); 
        }
    }

    private void HandleHit()
    {
        if (gameManager != null)
        {
            gameManager.AddScore(scoreValue); 
            
        }
        
        
        Destroy(gameObject); 
    }
}
