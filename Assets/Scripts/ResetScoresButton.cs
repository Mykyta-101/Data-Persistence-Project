using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScoresButton : MonoBehaviour
{
    // Start is called before the first frame update
   public void ResetScores()
    {
        GameManager.Instance.maxScore = 0;
        GameManager.Instance.maxScore2 = 0;
        GameManager.Instance.maxScore3 = 0;
        GameManager.Instance.bestScorePlayerNameText = "Player 1";
        GameManager.Instance.bestScorePlayerNameText2 = "Player 2";
        GameManager.Instance.bestScorePlayerNameText3 = "Player 3";
    }

    

}
