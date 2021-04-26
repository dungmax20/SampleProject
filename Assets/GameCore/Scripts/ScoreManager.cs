using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    
    [SerializeField] Image[] imgScores;
    [SerializeField] public int score;
    [SerializeField] public int best=0;
    [SerializeField] Sprite[] spriteOfNumbers;
    private void Awake()
    {
        instance = this;
        GameStateManager.GameStateChanged += GameStateChanged;
    }
    private void GameStateChanged()
    {
        if (GameStateManager.CurrentState == GameState.Play)
        {
            score = 0;
            best = PlayerPrefs.GetInt("best", best);
            UpdateImgScore();
        }
    }
    public void AddScore(int addScore)
    {
        score += addScore;
        if (best < score)
        {
            best = score;
            PlayerPrefs.SetInt("best", best);
            PlayerPrefs.Save();
        }
            
        UpdateImgScore();
    }
    public void UpdateImgScore()
    {
        if (score > 99999)
            score = 99999;
        var donvi = score % 10;
        var chuc = (score / 10) % 10;
        var tram = (score / 100) % 10;
        var nghin = (score / 1000) % 10;
        var chucnghin = (score / 10000) % 10;

        imgScores[0].sprite = spriteOfNumbers[donvi];
        imgScores[1].sprite = spriteOfNumbers[chuc];
        imgScores[2].sprite = spriteOfNumbers[tram];
        imgScores[3].sprite = spriteOfNumbers[nghin];
        imgScores[4].sprite = spriteOfNumbers[chucnghin];

        imgScores[1].gameObject.SetActive(chuc > 0);
        imgScores[2].gameObject.SetActive(tram > 0);
        imgScores[3].gameObject.SetActive(nghin > 0);
        imgScores[4].gameObject.SetActive(chucnghin> 0);
    }
}
