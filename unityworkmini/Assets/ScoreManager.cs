using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
//using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static ScoreManager instance;
    string filename = "";
    string input = "";
    [System.Serializable]
    public class Player
    {
        Level[] levels =new Level[5];
    }
    public class Level
    {
        SubLevel[] sublevels=new SubLevel[7];
    }
    public class SubLevel
    {
        int velocity;
        int score;
        float responseTime;
        float accuracy;
    }
   
    [System.Serializable]
    public class PlayerList
    {
        public List<Player> player;
    }
    public PlayerList myPlayer = new PlayerList();
    
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI chanceText;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI hittimeText;
    int score = 0;
    int chance = 3;
    int level = 1;
    int[] scorecard = new int[6];
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
       // TextAsset testdata = Load<TextAsset>("test");
       // string[] data = testdata.text.Split(new char[] { '\n' });
       // Debug.Log(data.Length);
        scoreText.text = "Score:"+ score.ToString()  ;
        filename = Application.dataPath + "/test.csv";
        Debug.Log(myPlayer);
    }
    void Update()
    {
       

    }
    // Update is called once per frame
    public void resethittime()
    {
        hittimeText.text = "HitTime:";
    }
    public void displayhittime(float timeElapsed)
    {
        hittimeText.text = "HitTime:" + timeElapsed.ToString();
    }
   public void AddPoint()
    {
        score += 10;
        scoreText.text = "Score:"+ score.ToString();
        
    }
    public void refreshchance()
    {
        chance = 3;
        chanceText.text = "Chances:" + chance.ToString() + " left";
    }
    public void Chances()
    {
        chance -= 1;
        chanceText.text = "Chances:" + chance.ToString()+" left";
        if (chance == 0)
        {
            Time.timeScale = 0f;
            chanceText.text = "Press R to restart";
            Time.timeScale = 0f;
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
        headlineCSV(level);
    }
    public int[] returnScoreCard()
    {
        return scorecard;
    }
    public void headlineCSV(int lvl)
    {
        TextWriter tw = new StreamWriter(filename, true);
        tw.WriteLine("Level:" + lvl);
      //  tw.Close();
     // tw = new StreamWriter(filename, true);
        tw.WriteLine("Velocity, Score, Response time");
        tw.Close();

    }
    public void WriteCSV(float velocity,float responseTime)
    {

        //  tw.WriteLine("Level, Score, Misses");
        //  tw.Close();
        TextWriter tw = new StreamWriter(filename, true);
        tw.WriteLine(velocity + "," + score + "," + responseTime);
        //tw.WriteLine(level +"," +score+","+ (3-chance));
         tw.Close();
    }
    public void ReadStringInput(string s)
    {
        input = s;
      //  Debug.Log(input);
    }
    public void onButton()
    {
        Debug.Log(input);
        TextWriter tw = new StreamWriter(filename, true);
        tw.WriteLine("Player:" + input);
        tw.WriteLine("Level:" + level);
        //tw.Close();

        tw.WriteLine("Velocity, Score, Response time");
        tw.Close();
    }
    public void readlines()
    {
       // TextWriter tw = new StreamWriter(filename, true);
        foreach (string line in File.ReadLines(@filename))
        {
            // Printing the file contents
            Debug.Log(line);
        }
    }
}
