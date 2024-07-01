using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManger : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;
    private int currentScore;
    private int bestScore;

    private static ScoreManger _instance;

    public static ScoreManger instance {
        get {return _instance; }
        set {; }

    }

    public int Score
    {
        get { return currentScore; }
        set {
            currentScore = value;
            if (currentScore > bestScore)
            {
                bestScore = currentScore;
                bestScoreText.text = "BestScore:" + bestScore;
                PlayerPrefs.SetInt("BestScore", bestScore);
            }
            scoreText.text = "Score:" + currentScore;



        }
    
    
    }
    private void Awake()
    {
        if (_instance == null) {
            _instance = this;
        }
    }
    public void SetScore(int value) {
        currentScore= value;
        PlayerPrefs.SetInt("BestScore", bestScore);
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            bestScoreText.text = "BestScore:" + bestScore;
            
        }
    }
    public int GetScore() { return currentScore; }
    // Start is called before the first frame update
    void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore",0);
        bestScoreText.text = "BestScore:" + bestScore;
       
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score:" + currentScore;

    }


}
