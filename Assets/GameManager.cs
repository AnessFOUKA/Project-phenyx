using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    // --- UI References (à assigner dans l'Inspector) ---
    public TextMesh scoreTextMesh;
    // NOUVEAU : Référence pour l'affichage du multiplicateur
    public TextMesh multiplierTextMesh; 
    
    // --- Score Variables ---
    private long currentScore = 0;
    // Score en attente d'être ajouté progressivement
    private long scoreToAddQueue = 0; 
    [Tooltip("Points ajoutés au score visible par seconde.")]
    public int scoreTickRate = 50000;  
    
    // --- Multiplier Variables ---
    private float currentMultiplier = 1.0f;
    [Tooltip("Augmentation du multiplicateur par seconde.")]
    public float multiplierIncreaseRate = 0.000013f; 
    public float maxMultiplier = 55.0f;

    void Start()
    {
        UpdateScoreDisplay();
        UpdateMultiplierDisplay();
    }

    void Update()
    {
        // Gère l'ajout progressif du score
        HandleScoreTick();
        
        // Gère l'augmentation progressive du multiplicateur au fil du temps
        HandleMultiplierIncrease();
    }
    
    // NOUVEAU : Gère l'augmentation progressive du score affiché
    private void HandleScoreTick()
    {
        if (scoreToAddQueue > 0)
        {
            // Calcule combien de points ajouter ce frame
            long pointsThisFrame = (long)(scoreTickRate * Time.deltaTime);

            // On s'assure de ne pas dépasser le montant total en attente
            pointsThisFrame = System.Math.Min(pointsThisFrame, scoreToAddQueue);

            currentScore += pointsThisFrame;
            scoreToAddQueue -= pointsThisFrame;

            UpdateScoreDisplay();
        }
    }

    // NOUVEAU : Gère l'augmentation progressive du multiplicateur
    private void HandleMultiplierIncrease()
    {
        // Augmente le multiplicateur tant qu'il n'a pas atteint la limite
        if (currentMultiplier < maxMultiplier)
        {
            currentMultiplier += multiplierIncreaseRate * Time.deltaTime;
            currentMultiplier = Mathf.Min(currentMultiplier, maxMultiplier);
            UpdateMultiplierDisplay();
        }
        // Vous pouvez ajouter ici une logique pour FAIRE BAISSER le multiplicateur s'il n'y a pas d'action !
    }

    // Modifié : Ajoute le score (brut * multiplicateur) à la file d'attente
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
    
    // NOUVEAU : Met à jour l'affichage du multiplicateur
    private void UpdateMultiplierDisplay()
    {
        if (multiplierTextMesh != null)
        {
            // Affichage avec deux décimales (ex: x 5.25)
            multiplierTextMesh.text = $"x {currentMultiplier:F2}";
        }
    }
}