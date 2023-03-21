using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
//using CsvHelper;
using UnityEngine.SceneManagement;
//using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static ScoreManager instance;
    bool noerror = true;
    string filename = "";
    bool prevuser = false;
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
    [SerializeField] TextMeshProUGUI errormessage;
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
        errormessage.enabled = false;
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
        if (chance < 0)
        {
            Time.timeScale = 0f;
            chanceText.text = "Press Space to restart";
            Time.timeScale = 0f;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
    public void onButtonprevuser()
    {
        prevuser = true;
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
        tw.WriteLine("Velocity, Score, Response time, Accuracy");
        tw.Close();

    }
    public void WriteCSV(float velocity,float responseTime,float accuracy,bool parame)
    {

        //  tw.WriteLine("Level, Score, Misses");
        //  tw.Close();
        TextWriter tw = new StreamWriter(filename, true);
        if (parame == false)
        {
            tw.WriteLine(velocity + "," + score + "," + responseTime + "," + "NA");
        }
        else
        {
            tw.WriteLine(velocity + "," + score + "," + responseTime  + "," + accuracy + "%");
        }
        
        //tw.WriteLine(level +"," +score+","+ (3-chance));
         tw.Close();
    }
    public void ReadStringInput(string s)
    {
        input = s;
      //  Debug.Log(input);
    }
    public void changeerrorstatus()
    {
        noerror = true;
    }
    public bool returnerrorstatus()
    {
        return noerror;
    }
    public void onButton()
    {
        Debug.Log(input);
        StreamReader tr = new StreamReader(filename);
        string[] lines = File.ReadAllLines(filename);
        if (prevuser == false)
        {
            foreach (string ln in lines)
            {
                if (ln.Equals("Player:" + input))
                {
                    errormessage.enabled = true;
                    noerror = false;
                    return;
                }
            }
        }
        tr.Close();
        TextWriter tw = new StreamWriter(filename, true);
        tw.WriteLine("Player:" + input);
        tw.WriteLine("Level:" + level);
        //tw.Close();

        tw.WriteLine("Velocity, Score, Response time ,Accuracy");
        tw.Close();
    }
    public void readlines()
    {
        StreamReader tr = new StreamReader(filename);
        string[] line= File.ReadAllLines(filename);
            //while ((line = tr.ReadLine()) != null)
       // {
           for(int i = 0; i < line.Length; i++)
        {
            Debug.Log(line[i]);
        }
        tr.Close();   
           
     //   }
       // TextWriter tw = new StreamWriter(filename, true);
       //  using(var streamReader=new StreamReader(@filename))
       // {
       //    using(var csvReader=new CsvReader(streamReader, CultureInfo.InvariantCulture))
       //    {
       //      var records = csvReader.GetRecords<dynamic>().ToList();
       //      Debug.Log(records);
       //  }
       //  }
    }
}
