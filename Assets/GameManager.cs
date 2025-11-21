using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public TextMesh scoreTextMesh;
    public TextMesh multiplierTextMesh; 
    
    
    private long currentScore = 0;
    
    private long scoreToAddQueue = 0; 
       
    
    private float currentMultiplier = 1.0f;

    public float multiplierIncreaseRate = 0.05f; 
    public float maxMultiplier = 15.0f;

    void Start()
    {
        UpdateScoreDisplay();
        UpdateMultiplierDisplay();
    }

    void Update()
    {
        // Gère l'ajout progressif du score affiché
        if (scoreToAddQueue > 0)
        {
            currentScore = scoreToAddQueue;
            UpdateScoreDisplay();
        }
        
        // Gère l'augmentation progressive du multiplicateur au fil du temps
        if (currentMultiplier < maxMultiplier)
        {
            currentMultiplier += multiplierIncreaseRate * Time.deltaTime;
            currentMultiplier = Mathf.Min(currentMultiplier, maxMultiplier);
            UpdateMultiplierDisplay();
        }
    }
    

    //Ajoute le score
    public void AddScore(int rawAmount)
    {
        // 1. Calculer le score total avec le multiplicateur
        long scoreWithMultiplier = (long)(rawAmount * currentMultiplier);
        
        // 2. Ajouter le résultat à la file d'attente
        scoreToAddQueue += scoreWithMultiplier;
    }

    // Mise à jour de l'affichage du score
    private void UpdateScoreDisplay()
    {
        if (scoreTextMesh != null)
        {
            scoreTextMesh.text = "Score: " + currentScore.ToString("D10");
        }
    }
    
    //Met à jour l'affichage du multiplicateur
    private void UpdateMultiplierDisplay()
    {
        if (multiplierTextMesh != null)
        {
            multiplierTextMesh.text = $"x {currentMultiplier:F2}";
        }
    }

    // private void ResetMultiplayer()
    // {
    //     currentMultiplier = 1.0f;
    //     UpdateMultiplierDispaly();

    //     //gameManager.ResetMultiplier(); a appeler depuis le PlayerScript quand le joueur se fait toucher
    // }
}