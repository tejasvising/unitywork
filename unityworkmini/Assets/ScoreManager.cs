using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static ScoreManager instance;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI levelText;
    int score = 0;
    int level = 1;
    int[] scorecard = new int[4];
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        scoreText.text = "Score:"+ score.ToString()  ;
    }
    // Update is called once per frame
   public void AddPoint()
    {
        score += 1;
        scoreText.text = "Score:"+ score.ToString();

    }
    public int returnScore()
    {
       
        return score;
    }
    public void AddLevel(int level)
    {
        level += 1;
        scorecard[level] = score;
        Debug.Log("level:"+level.ToString());
        levelText.text = "Level:" + level.ToString();
    }
    public int[] returnScoreCard()
    {
        return scorecard;
    }
}
