using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HallOfFame : MonoBehaviour
{
    public TextMeshProUGUI bestScores1;
    public TextMeshProUGUI bestScores2;
    public TextMeshProUGUI bestScores3;
    // Start is called before the first frame update
    void Start()
    {
    bestScores1.text = "1." + GameManager.Instance.bestScorePlayerNameText + " - score: " + GameManager.Instance.maxScore;
    bestScores2.text = "2." + GameManager.Instance.bestScorePlayerNameText2 + " - score: " + GameManager.Instance.maxScore2;
    bestScores3.text = "3." + GameManager.Instance.bestScorePlayerNameText3 + " - score: " + GameManager.Instance.maxScore3;
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
