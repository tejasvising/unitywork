using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static ScoreManager instance;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI chanceText;
    [SerializeField] TextMeshProUGUI levelText;
    int score = 0;
    int chance = 0;
    int level = 1;
    int[] scorecard = new int[6];
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        scoreText.text = "Score:"+ score.ToString()  ;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
    // Update is called once per frame
   public void AddPoint()
    {
        score += 1;
        scoreText.text = "Score:"+ score.ToString();

    }
    public void Chances()
    {
        chance += 1;
        chanceText.text = "Chances:" + chance.ToString();
        if (chance == 3)
        {
            Time.timeScale = 0f;
            chanceText.text = "Press R to restart";
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
    public int returnChance()
    {
        return chance;
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
