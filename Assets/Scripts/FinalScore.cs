using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI finalScore;
    GameSession gameSession;
    void Start()
    {
       gameSession = FindFirstObjectByType<GameSession>();
       FinScore(); 
    }


    void FinScore()
    {
        finalScore.text = "FINAL SCORE:\n" + gameSession.GetScore().ToString();
    }
}
