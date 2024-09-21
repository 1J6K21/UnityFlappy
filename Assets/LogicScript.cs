using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using System;
public class LogicScript : MonoBehaviour
{
    
    public int coinsObtained;
    public Text coinsText;
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;

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
        gameOverScreen.SetActive(true);

        ScoreManager scoreManager = GameObject.FindFirstObjectByType<ScoreManager>();
        GameData newGameData = scoreManager.GetGameData();
        if(newGameData.GetBestScore() < playerScore) {
            newGameData.SetBestScore(playerScore);
            scoreManager.SetGameData(newGameData);
            scoreManager.saveData();
        }
        

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
