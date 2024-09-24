using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using System;
using Unity.VisualScripting;
public class LogicScript : MonoBehaviour
{
    public Sprite[] sprites; //[default, bronze, silver, gold]
    public Image Medal;
    public int coinsObtained;
    public Text coinsText;
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;

    public Text endScoreText;

    public Text bestScoreText;


    [ContextMenu("Increase Score")]
    public void AddScore(int scoreToAdd){

        if(!gameOverScreen.activeSelf){
            playerScore += scoreToAdd;
            scoreText.text = playerScore.ToString();
        }
    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver(){
        
        if(playerScore > 50){
            Medal.sprite = sprites[3];
        }else if(playerScore > 25){
            Medal.sprite = sprites[2];
        }else if(playerScore > 10){
            Medal.sprite = sprites[1];
        }else{
            Medal.sprite = sprites[0];
            
        }
        

        endScoreText.text = $"{playerScore}";
        ScoreManager scoreManager = GameObject.FindFirstObjectByType<ScoreManager>();
        GameData newGameData = scoreManager.GetGameData();
        int tempBest = newGameData.GetBestScore();
        if(tempBest < playerScore) {
            newGameData.SetBestScore(playerScore);
            scoreManager.SetGameData(newGameData);
            scoreManager.saveData();
            bestScoreText.text = $"{playerScore}";
        }else{
            bestScoreText.text = $"{tempBest}";
        }
        
        gameOverScreen.SetActive(true);

    }

    public void AddCoinScore(int coins){
        coinsObtained += coins;
        coinsText.text = $"{coinsObtained}";
    }

    [ContextMenu("LoadData")]
    public void TestData(){
        ScoreManager scoreManager = GameObject.FindFirstObjectByType<ScoreManager>();
        scoreManager.ReadData();
    }
}
