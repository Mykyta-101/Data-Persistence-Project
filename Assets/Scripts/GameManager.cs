using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int maxScore ;
    public string bestScorePlayerNameText;
    public int maxScore2;
    public string bestScorePlayerNameText2;
    public int maxScore3;
    public string bestScorePlayerNameText3;
    public string currentPlayerNameText;

    [System.Serializable]
    class SaveData
    {
        public int[] topScores ;
        public string[] topPlayers;
    }



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
        LoadTopScores();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
   
    // Update is called once per frame


   

    public void CheckBestResult (int currentScore, string currentName)
    {
        if (currentScore >= maxScore+1)
        {
            maxScore3 = maxScore2;
            bestScorePlayerNameText3 = bestScorePlayerNameText2;
            maxScore2 = maxScore;
            bestScorePlayerNameText2 = bestScorePlayerNameText;
            maxScore = currentScore;
            bestScorePlayerNameText = currentName;
        }
        else if(currentScore >= maxScore2 + 1)
        {
            maxScore3 = maxScore2;
            bestScorePlayerNameText3 = bestScorePlayerNameText2;
            maxScore2 = currentScore;
            bestScorePlayerNameText2 = currentName;
        }
        else if (currentScore >= maxScore3 + 1)
        {
            maxScore3 = currentScore;
            bestScorePlayerNameText3 = currentName;
        }
    }

    public void SaveTopScores()
    {
        SaveData data = new SaveData();
        data.topScores = new int[3] { maxScore, maxScore2, maxScore3 };
        data.topPlayers = new string[3] { bestScorePlayerNameText, bestScorePlayerNameText2, bestScorePlayerNameText3 };

        // Сохраняем текущие топ-3 из GameManager
        data.topScores[0] = maxScore;
        data.topScores[1] = maxScore2;
        data.topScores[2] = maxScore3;

        data.topPlayers[0] = bestScorePlayerNameText;
        data.topPlayers[1] = bestScorePlayerNameText2;
        data.topPlayers[2] = bestScorePlayerNameText3;

        // Конвертируем в JSON и сохраняем в файл
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadTopScores()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            if (data != null)
            {
                maxScore = data.topScores[0];
                maxScore2 = data.topScores[1];
                maxScore3 = data.topScores[2];

                bestScorePlayerNameText = data.topPlayers[0];
                bestScorePlayerNameText2 = data.topPlayers[1];
                bestScorePlayerNameText3 = data.topPlayers[2];
            }
        }
        else
        {
            Debug.Log("Save file not found, starting fresh.");
            // Здесь можно обнулить или установить значения по умолчанию
            maxScore = 0;
            maxScore2 = 0;
            maxScore3 = 0;
            bestScorePlayerNameText = "Player 1";
            bestScorePlayerNameText2 = "Player 2";
            bestScorePlayerNameText3 = "Player 3";
        }
    }

}
