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
    public Sprite[] nums; //num sprites [0-9]
    public Image[] digitImages; //Images from canvas displaying the digits of score
    public Image[] coinScore; //Images from canvas displaying coins' digits
    public Image Medal; //Image of selected medal from sprites [default, bronze, silver, gold]
    public int coinsObtained; //integer coin score
    public int playerScore; //integer player score
    public GameObject gameOverScreen;

    public Text endScoreText; //Text of endscreen score

    public Text bestScoreText; //Text of endscreen best score


    [ContextMenu("Increase Score")]
    public void AddScore(int scoreToAdd){

        if(!gameOverScreen.activeSelf){
            if(playerScore == 9999){
                GameOver();
            }else{
                playerScore += scoreToAdd;

                string digitsString = playerScore.ToString();
                for(int i = 0; i< digitsString.Length; i++){
                    digitImages[i].enabled = true;
                    digitImages[i].sprite = nums[int.Parse(digitsString[i].ToString())];
                }
            }
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
        

        if(!gameOverScreen.activeSelf){
            if(coinsObtained == 99){
                GameOver();
            }else{
                coinsObtained += coins;

                string digitsString = coinsObtained.ToString();
                for(int i = 0; i< digitsString.Length; i++){
                    coinScore[i].enabled = true;
                    coinScore[i].sprite = nums[int.Parse(digitsString[i].ToString())];
                }
            }
        }
        
    }

    public void StartNums(){
        digitImages[0].sprite = nums[0];
        digitImages[1].enabled = false;
        digitImages[2].enabled = false;
        digitImages[3].enabled = false;
        coinScore[0].sprite = nums[0];
        coinScore[1].enabled = false;
    }

    [ContextMenu("LoadData")]
    public void TestData(){
        ScoreManager scoreManager = GameObject.FindFirstObjectByType<ScoreManager>();
        scoreManager.ReadData();
    }
}
