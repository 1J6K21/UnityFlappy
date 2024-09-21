using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int personalBest;

    public int GetBestScore(){
        return personalBest;
    }

    public void SetBestScore(int newScore){
        personalBest = newScore;
    }
}

public class ScoreManager : MonoBehaviour
{
    private String filePath;
    private GameData gameData = new GameData();

    
    void Start(){
        filePath = Application.persistentDataPath + "/gameData.json";
        ReadData();
    }

    public void ReadData(){
        if(File.Exists(filePath)){
            string json = File.ReadAllText(filePath);
            gameData = JsonUtility.FromJson<GameData>(json);
            Debug.Log("best score " + gameData.GetBestScore());
        }else{
            Debug.LogWarning("No saved files found");
        }
    }

    public void saveData(){
        string json = JsonUtility.ToJson(gameData); //converts the gameData object to json
        File.WriteAllText(filePath, json); //writes the json string to path
        Debug.Log("saved gameData succesfully");
    }

    public GameData GetGameData(){
        return gameData;
    }

    public void SetGameData(GameData gameData){
        this.gameData = gameData;
    }
}
