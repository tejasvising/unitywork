
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using TMPro;
public class Try : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] TextMeshProUGUI disclaimer;
    [SerializeField] TextMeshProUGUI errormessage;
    [SerializeField] TextMeshProUGUI info;
    public TMP_InputField InputField;
   // public Text input;
    public Button button;
    public Button button1;
    public Button button2;

    // Start is called before the first frame update
    private Rigidbody rb;
 
    private Rigidbody rigidbodyoffalsetarget2;
    private Rigidbody trb;
    private Rigidbody rigbodyofnewTargetobjinlevel2;
   // private Rigidbody rigidbodyofnewfalseobjinlevel4;
  //  private Rigidbody rigidbodyofnewfalseobjinlevel5;
    private Rigidbody rigidbodyofnewtargetobjinlevel3;
    private Rigidbody rigidbodyofnewtargetobjinlevel5;
    private Rigidbody rigidbodyofnewtargetobjinlevel4;
  //  private Rigidbody cl;
    //private Rigidbody ce;

    public GameObject FalseTarget2;
    public GameObject Sphere;
    public GameObject go;
    public GameObject ge;
 //   public GameObject newfalseobjinlevel4;
  //  public GameObject newfalseobjinlevel5;
    public GameObject Targeted;
    public GameObject newTargetobjinlevel5;
    public GameObject newTargetobjinlevel4;
    public GameObject newTargetobjinlevel2;
    public GameObject newTargetobjinlevel3;
    
    int level = 1;

    // [SerializeField] BoxCollider col;


    void Start()
    {
       
        Sphere = GameObject.Find("FalseTarget");
        Targeted = GameObject.Find("Target");
       
        FalseTarget2 = GameObject.Find("FalseTarget2");
     //   go = GameObject.Instantiate(Sphere);
        newTargetobjinlevel2 = GameObject.Instantiate(Targeted);
      //  go.SetActive(false);
        newTargetobjinlevel2.SetActive(false);
       // ge = GameObject.Instantiate(Sphere);
        newTargetobjinlevel3 = GameObject.Instantiate(Targeted);
      //  ge.SetActive(false);

        newTargetobjinlevel3.SetActive(false);
     //   newfalseobjinlevel4 = GameObject.Instantiate(Sphere);
     //   newfalseobjinlevel4.SetActive(false);
        newTargetobjinlevel4 =GameObject.Instantiate(Targeted);
      newTargetobjinlevel4.SetActive(false);
     //   newfalseobjinlevel5 = GameObject.Instantiate(Sphere);
     //   newfalseobjinlevel5.SetActive(false);
        newTargetobjinlevel5 = GameObject.Instantiate(Targeted);
         newTargetobjinlevel5.SetActive(false);
       
       
        trb = Targeted.GetComponent<Rigidbody>();
        rb = Sphere.GetComponent<Rigidbody>();

        rigidbodyoffalsetarget2 = FalseTarget2.GetComponent<Rigidbody>();
     
       
        //Invoke("feedDog", 5);
    //  yield return  StartCoroutine(level1(x));
      
    }
   public void buttonOnClick()
    {
       
        ScoreManager.instance.onButton();
        //input.DeactivateInputField();
        if (ScoreManager.instance.returnerrorstatus())
        {
            InputField.gameObject.SetActive(false);
            // Destroy(InputField.gameobject);
            Destroy(button.gameObject);
            Destroy(button1.gameObject);
            Destroy(button2.gameObject);
            info.enabled = false;
            errormessage.enabled = false;
            StartCoroutine(Colorchangeinstart(5f));
        }
        ScoreManager.instance.changeerrorstatus();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
           
        }
    }
        void OnCollisionEnter(Collision collision)
    {
        
       // if (collision.gameObject.name == "Cube")
       // {
         
        //if (rb.velocity.y >= 0)
        // {
      //  reflectedObject.position = Vector3.Reflect(originalObject.position, Vector3.right);
        Vector3 tempVect = new Vector3(rb.velocity.x * -1, rb.velocity.y*-1 , rb.velocity.z*-1 );
                rb.velocity = -rb.velocity.normalized;
          //  }
          //  else
          //  {
          //      Vector3 tempVect = new Vector3(rb.velocity.x * -1, rb.velocity.y*-1, rb.velocity.z * -1);
           //     rb.velocity = tempVect;
          //  }

           
       // }
    }
    public IEnumerator Colorchangeinstart(float pauseTime)
    {

        Targeted.GetComponent<Renderer>().material.color = Color.white;
        float pauseEndTime = Time.realtimeSinceStartup + pauseTime;
        Time.timeScale = 0f;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {

            yield return 0;
        }
        Time.timeScale = 1f;

        Targeted.GetComponent<Renderer>().material.color = new Color(0.7710f, 0.9339f, 0.1533f, 1f);
        rb.velocity = new Vector3(-1f, 0f, 1f);

        rigidbodyoffalsetarget2.velocity = new Vector3(-1f, 0f, 1f);
        //  rb2.velocity = new Vector3(-1f, 0f, 1f);
        trb.velocity = new Vector3(-1f, 0f, 1f);
        var x = 1f;
        StartCoroutine(level1(x));
    }
    public IEnumerator Colorchangeinlvl1(float pauseTime)
    {
        
        Targeted.GetComponent<Renderer>().material.color = Color.white;
        float pauseEndTime = Time.realtimeSinceStartup + pauseTime;
        Time.timeScale = 0f;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
           
            yield return 0;
        }
        Time.timeScale = 1f;
        
        Targeted.GetComponent<Renderer>().material.color = new Color(0.7710f, 0.9339f, 0.1533f, 1f);
    }
    public IEnumerator Colorchangeinlvl2(float pauseTime)
    {
        newTargetobjinlevel2.GetComponent<Renderer>().material.color =Color.white;
        Targeted.GetComponent<Renderer>().material.color = Color.white;
       
        float pauseEndTime = Time.realtimeSinceStartup + pauseTime;
        Time.timeScale = 0f;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {

            yield return 0;
        }
        Time.timeScale = 1f;
        

        newTargetobjinlevel2.GetComponent<Renderer>().material.color = new Color(0.7710f, 0.9339f, 0.1533f, 1f);
        Targeted.GetComponent<Renderer>().material.color = new Color(0.7710f, 0.9339f, 0.1533f, 1f);
    }
    public IEnumerator Colorchangeinlvl3(float pauseTime)
    {
        newTargetobjinlevel2.GetComponent<Renderer>().material.color =Color.white;
        newTargetobjinlevel3.GetComponent<Renderer>().material.color = Color.white;
        Targeted.GetComponent<Renderer>().material.color =Color.white;
        float pauseEndTime = Time.realtimeSinceStartup + pauseTime;
        Time.timeScale = 0f;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {

            yield return 0;
        }
        Time.timeScale = 1f;
        newTargetobjinlevel2.GetComponent<Renderer>().material.color = new Color(0.7710f, 0.9339f, 0.1533f, 1f);
        newTargetobjinlevel3.GetComponent<Renderer>().material.color = new Color(0.7710f, 0.9339f, 0.1533f, 1f);
        Targeted.GetComponent<Renderer>().material.color = new Color(0.7710f, 0.9339f, 0.1533f, 1f);
    }
    public IEnumerator Colorchangeinlvl4(float pauseTime)
    {
        newTargetobjinlevel2.GetComponent<Renderer>().material.color = Color.white;
        newTargetobjinlevel3.GetComponent<Renderer>().material.color =  Color.white;
        newTargetobjinlevel4.GetComponent<Renderer>().material.color = Color.white;
        Targeted.GetComponent<Renderer>().material.color = Color.white;

        float pauseEndTime = Time.realtimeSinceStartup + pauseTime;
        Time.timeScale = 0f;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {

            yield return 0;
        }
        Time.timeScale = 1f;
        newTargetobjinlevel2.GetComponent<Renderer>().material.color = new Color(0.7710f, 0.9339f, 0.1533f, 1f);
        newTargetobjinlevel3.GetComponent<Renderer>().material.color = new Color(0.7710f, 0.9339f, 0.1533f, 1f);
        newTargetobjinlevel4.GetComponent<Renderer>().material.color = new Color(0.7710f, 0.9339f, 0.1533f, 1f);
        Targeted.GetComponent<Renderer>().material.color = new Color(0.7710f, 0.9339f, 0.1533f, 1f);
    }
    public IEnumerator Colorchangeinlvl5(float pauseTime)
    {

        newTargetobjinlevel2.GetComponent<Renderer>().material.color = Color.white;
        newTargetobjinlevel3.GetComponent<Renderer>().material.color = Color.white;
        newTargetobjinlevel4.GetComponent<Renderer>().material.color = Color.white;
        newTargetobjinlevel5.GetComponent<Renderer>().material.color =Color.white;
        Targeted.GetComponent<Renderer>().material.color =Color.white;
        float pauseEndTime = Time.realtimeSinceStartup + pauseTime;
        Time.timeScale = 0f;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {

            yield return 0;
        }
        Time.timeScale = 1f;
        newTargetobjinlevel2.GetComponent<Renderer>().material.color = new Color(0.7710f, 0.9339f, 0.1533f, 1f);
        newTargetobjinlevel3.GetComponent<Renderer>().material.color = new Color(0.7710f, 0.9339f, 0.1533f, 1f);
        newTargetobjinlevel4.GetComponent<Renderer>().material.color = new Color(0.7710f, 0.9339f, 0.1533f, 1f);
        newTargetobjinlevel5.GetComponent<Renderer>().material.color = new Color(0.7710f, 0.9339f, 0.1533f, 1f);
        Targeted.GetComponent<Renderer>().material.color = new Color(0.7710f, 0.9339f, 0.1533f, 1f);
    }
    public void feedDog()
    {

        //    rb = gameObject.GetComponent<Rigidbody>();

        Debug.Log("iaminfeeddog");
       
       // Sphere2=GameObject.Find("Sphere2");
       
     //   rb2= Sphere2.GetComponent<Rigidbody>();
        trb= Targeted.GetComponent<Rigidbody>();
        rb = Sphere.GetComponent<Rigidbody>();
     
        rigidbodyoffalsetarget2 = FalseTarget2.GetComponent<Rigidbody>();
        rb.velocity =new Vector3(-1f,0f,1f);
       
        rigidbodyoffalsetarget2.velocity = new Vector3(-1f, 0f, 1f);
        //  rb2.velocity = new Vector3(-1f, 0f, 1f);
        trb.velocity = new Vector3(1f, 0f, -1f);
        var x = 1f;
       
       
            StartCoroutine(level1(x));
      

    }
    //  public IEnumerator keepconstVelocitylvl1(float duration)
    //  {
    //     rb.velocity = constantSpeed * (rb.velocity.normalized);
    //     trb.velocity = constantSpeed * (trb.velocity.normalized);
    // }
    public IEnumerator keepconstvelinlvl1(float pauseTime,float x)
  {
        //    Debug.Log("Inside PauseGame()");
              

        float pauseEndTime = Time.realtimeSinceStartup + pauseTime;
    while (Time.realtimeSinceStartup < pauseEndTime)
     {
            Vector3 holdr = rb.velocity / rb.velocity.magnitude;
            //  Vector3 tempVect = new Vector3(x, y * 0, z );
            rb.velocity = holdr * x;
            // rb.velocity = rb.velocity.normalized * x;
            trb.velocity = trb.velocity.normalized * x;
            rigidbodyoffalsetarget2.velocity = rigidbodyoffalsetarget2.velocity.normalized * x;
            yield return 0;
        }

       
   
     }
    public IEnumerator keepconstvelinlvl2(float pauseTime, float x)
    {
    

        float pauseEndTime = Time.realtimeSinceStartup + pauseTime;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            rb.velocity = rb.velocity.normalized * x;
            trb.velocity = trb.velocity.normalized * x;
            rigidbodyoffalsetarget2.velocity = rigidbodyoffalsetarget2.velocity.normalized * x;
            rigbodyofnewTargetobjinlevel2.velocity = rigbodyofnewTargetobjinlevel2.velocity.normalized * x;
          //  cl.velocity = cl.velocity.normalized * x;
            yield return 0;
        }

      

    }
    public IEnumerator keepconstvelinlvl3(float pauseTime, float x)
    {
 

        float pauseEndTime = Time.realtimeSinceStartup + pauseTime;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            rb.velocity = rb.velocity.normalized * x;
            trb.velocity = trb.velocity.normalized * x;
            rigidbodyoffalsetarget2.velocity = rigidbodyoffalsetarget2.velocity.normalized * x;
            rigbodyofnewTargetobjinlevel2.velocity = rigbodyofnewTargetobjinlevel2.velocity.normalized * x;
            rigidbodyofnewtargetobjinlevel3.velocity = rigidbodyofnewtargetobjinlevel3.velocity.normalized * x;
            //cl.velocity = cl.velocity.normalized * x;
           // ce.velocity = ce.velocity.normalized * x;
            yield return 0;
        }


    }
   
    public IEnumerator keepconstvelinlvl5(float pauseTime, float x)
    {
       

        float pauseEndTime = Time.realtimeSinceStartup + pauseTime;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            rb.velocity = rb.velocity.normalized * x;
            trb.velocity = trb.velocity.normalized * x;
            rigidbodyoffalsetarget2.velocity = rigidbodyoffalsetarget2.velocity.normalized * x;
            rigbodyofnewTargetobjinlevel2.velocity = rigbodyofnewTargetobjinlevel2.velocity.normalized * x;
            rigidbodyofnewtargetobjinlevel3.velocity = rigidbodyofnewtargetobjinlevel3.velocity.normalized * x;
            rigidbodyofnewtargetobjinlevel4.velocity = rigidbodyofnewtargetobjinlevel4.velocity.normalized * x;
            rigidbodyofnewtargetobjinlevel5.velocity = rigidbodyofnewtargetobjinlevel5.velocity.normalized * x;
           // rigidbodyofnewfalseobjinlevel4.velocity = rigidbodyofnewfalseobjinlevel4.velocity.normalized * x;
           // rigidbodyofnewfalseobjinlevel5.velocity = rigidbodyofnewfalseobjinlevel5.velocity.normalized * x;
          //  cl.velocity = cl.velocity.normalized * x;
          //  ce.velocity = ce.velocity.normalized * x;
            yield return 0;
        }


    }
    public IEnumerator keepconstvelinlvl4(float pauseTime, float x)
    {
  

        float pauseEndTime = Time.realtimeSinceStartup + pauseTime;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            rb.velocity = rb.velocity.normalized * x;
            trb.velocity = trb.velocity.normalized * x;
            rigidbodyoffalsetarget2.velocity = rigidbodyoffalsetarget2.velocity.normalized * x;
            rigbodyofnewTargetobjinlevel2.velocity = rigbodyofnewTargetobjinlevel2.velocity.normalized * x;
            rigidbodyofnewtargetobjinlevel3.velocity = rigidbodyofnewtargetobjinlevel3.velocity.normalized * x;
            rigidbodyofnewtargetobjinlevel4.velocity = rigidbodyofnewtargetobjinlevel4.velocity.normalized * x;
          //  rigidbodyofnewfalseobjinlevel4.velocity = rigidbodyofnewfalseobjinlevel4.velocity.normalized * x;
          //  cl.velocity = cl.velocity.normalized * x;
          //  ce.velocity = ce.velocity.normalized * x;
            yield return 0;
        }

        

    }
    public IEnumerator PauseGame(float pauseTime,float velocity)
    {
        //    Debug.Log("Inside PauseGame()");
        if (velocity <= 6) pauseTime = 3f; int accuracy = 0;
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        var t = Time.realtimeSinceStartup;float responseTime=5f;
        Time.timeScale = 0f;bool correcthit = false;
        int cnt = 0;bool hitdone = false;
        float pauseEndTime = Time.realtimeSinceStartup + pauseTime;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                // Ray ray = cam.ViewportPointToRay(new Vector3(0.5f,0.5f));
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                // Debug.Log(ray);
                Debug.DrawRay(ray.origin, ray.direction * 1000, Color.green, 1000, true);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    cnt++;hitdone = true;
                    Target target = hit.collider.gameObject.GetComponent<Target>();
                    FalseTarget falsetarget = hit.collider.gameObject.GetComponent<FalseTarget>();
                    if (cnt == 1) { responseTime = Time.realtimeSinceStartup - t; }
                    
                    if (falsetarget != null)
                    {
                       if (ScoreManager.instance.returnChance() == 0) {
                            ScoreManager.instance.WriteCSV(velocity, responseTime, accuracy,true);
                        }
                            falsetarget.collide();
                        
                    }
                    // Debug.Log(target);
                    if (target != null)
                    {
                        // Destroy(target.gameObject);

                        //score++;
                        //  score++;
                        //  scoreText.text = "Score:" + score;
                        //target.Hit();
                        correcthit = true;
                        ScoreManager.instance.AddPoint();
                    }
                }
            }
                ScoreManager.instance.displayhittime(Mathf.FloorToInt(Time.realtimeSinceStartup - t));
          //  Debug.Log(Time.realtimeSinceStartup-t);
            yield return 0;
        }
        
        if (ScoreManager.instance.returnChance() == 3 && correcthit==true ) { accuracy = 100; }
        else if(ScoreManager.instance.returnChance() == 2 && correcthit == true)
        {
            accuracy = 75;
           
        }
        else if(ScoreManager.instance.returnChance() == 1 && correcthit == true)
        {
            accuracy = 50;
        }
        else if(ScoreManager.instance.returnChance() == 0 && correcthit == true)
        {
            accuracy = 25;
        }
        if (cnt == 0)
        {
            ScoreManager.instance.WriteCSV(velocity, responseTime, accuracy, false);
        }
        else
        {
            ScoreManager.instance.WriteCSV(velocity, responseTime, accuracy, true);
        }
        
        ScoreManager.instance.readlines();
        //  if(hitdone==false) ScoreManager.instance.WriteCSV(velocity, 5f);
        ScoreManager.instance.resethittime();
        Time.timeScale = 1f;
        ScoreManager.instance.refreshchance();
    }
    IEnumerator ShowMessage(string message, float delay)
    {
        disclaimer.text = message;
       disclaimer.enabled = true;
        Time.timeScale = 0f;
       
        float pauseEndTime = Time.realtimeSinceStartup + 3f;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
            
        Time.timeScale = 1f;
        disclaimer.enabled = false;
    }
    public IEnumerator level1(float x)
    {
        //Print the time of when the function is first called.
        Targeted.GetComponent<Renderer>().material.color = new Color(0.7710f, 0.9339f, 0.1533f, 1f);
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
       
        int limiter = 1;
        int loopCap = 8;
        //yield on a new YieldInstruction that waits for 5 seconds 
      while (limiter < loopCap)
            {
            // new WaitForSeconds(1);
    
            yield return StartCoroutine(keepconstvelinlvl1(10f,x));
            yield return StartCoroutine(ShowMessage("You are given time to hit the target now", 3f));
            yield return StartCoroutine(PauseGame(5f,x));
            yield return StartCoroutine(Colorchangeinlvl1(3f));
            
                
        
            Debug.Log(rb.velocity);
            Vector3 holdr = rb.velocity / rb.velocity.magnitude;
                //  Vector3 tempVect = new Vector3(x, y * 0, z );
                rb.velocity =holdr* x;
                Debug.Log(rb.velocity.magnitude);
                Vector3 holdrb = trb.velocity / trb.velocity.magnitude;
                // Vector3 temprb = new Vector3(x , y * 0, c);
                trb.velocity = trb.velocity.normalized * x;
            rigidbodyoffalsetarget2.velocity = rigidbodyoffalsetarget2.velocity.normalized * x;
            // Vector3 temprb1 = new Vector3(c, y * 0, z);

            // Vector3 temprb2 = new Vector3(c, y * 0, c);
            //Vector3 holdr2 = rb2.velocity / rb2.velocity.magnitude;
            // rb2.velocity = holdr2 * x;
            //  c--;
            if (limiter == 1)
            {
                x += 2;
                limiter++;
                continue;
            }
                x+=3;
            //  y++;
            //  z++;
            
           // yield return WaitUntil(() => coroutineOver !=true);
            limiter++;
            }
 //After we have waited 5 seconds print the time again.
      
        // StartPause();
      
        ScoreManager.instance.AddLevel(level);
        level++;
        ScoreManager.instance.refreshchance();
        //  go.SetActive(true);
        newTargetobjinlevel2.SetActive(true);

        //     newTargetobjinlevel2.GetComponent<Renderer>().material.color = Color.white;
        //      Targeted.GetComponent<Renderer>().material.color = Color.white;
        
        StartCoroutine(level2(1f));
        yield return null;

       // displayset();
    }
    

   

    IEnumerator level2(float x)
    {
        //Print the time of when the function is first called.

        yield return StartCoroutine(Colorchangeinlvl2(3f));
        rigbodyofnewTargetobjinlevel2 = newTargetobjinlevel2.GetComponent<Rigidbody>();
   //  cl=   go.GetComponent<Rigidbody>();
   // cl.velocity = new Vector3(-1f, 0, 1f);
        rigbodyofnewTargetobjinlevel2.velocity = new Vector3(-1f, 0f, 1f);
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        int limiter = 1;

        int loopCap = 8;
        //yield on a new YieldInstruction that waits for 5 seconds.

        while (limiter < loopCap)
        {
            yield return StartCoroutine(keepconstvelinlvl2(10f, x));
            yield return StartCoroutine(ShowMessage("You are given 5 seconds to hit the target now", 3f));
            yield return StartCoroutine(PauseGame(5f,x));
    
            yield return StartCoroutine(Colorchangeinlvl2(3f));
     
            Debug.Log("done with wait");
            Vector3 holdr = rb.velocity / rb.velocity.magnitude;
            //  Vector3 tempVect = new Vector3(x, y * 0, z );
            rb.velocity = holdr * x;
            Debug.Log(rb.velocity.magnitude);
            Vector3 holdrb = trb.velocity / trb.velocity.magnitude;
            // Vector3 temprb = new Vector3(x , y * 0, c);
            trb.velocity = holdrb * x;
            // Vector3 temprb1 = new Vector3(c, y * 0, z);
            Vector3 dircompofnewTargetobjinlevel2 = rigbodyofnewTargetobjinlevel2.velocity / rigbodyofnewTargetobjinlevel2.velocity.magnitude;
            rigbodyofnewTargetobjinlevel2.velocity = dircompofnewTargetobjinlevel2 * x;
            // Vector3 temprb2 = new Vector3(c, y * 0, c);
            // Vector3 holdr2 = rb2.velocity / rb2.velocity.magnitude;
            // rb2.velocity = holdr2 * x;
            rigidbodyoffalsetarget2.velocity = rigidbodyoffalsetarget2.velocity.normalized * x;
         //   Vector3 clr = cl.velocity / cl.velocity.magnitude;
       //     cl.velocity = clr * x;
            //  c--;
            if (limiter == 1)
            {
                x += 2;
                limiter++;
                continue;
            }
            x +=3;
            //  y++;
            //  z++;
         
            
            limiter++;
        }
        //After we have waited 5 seconds print the time again.

        Debug.Log("Finished Coroutine at timestamp : " + Time.time);

        //StartPause2(newTargetobjinlevel2);
        ScoreManager.instance.AddLevel(level);
        level++;
        ScoreManager.instance.refreshchance();
        StartCoroutine(level3(1f));
       // displayset2();
    }
   
    void displayset2()
   {
        
       
        StartCoroutine(level3(1f));
    }
    IEnumerator level3(float x)
    {
        //Print the time of when the function is first called.
       
        Debug.Log("level3 says i am here");
     //   ge.SetActive(true);
        newTargetobjinlevel3.SetActive(true);
        yield return StartCoroutine(Colorchangeinlvl3(3f));
        rigidbodyofnewtargetobjinlevel3 = newTargetobjinlevel3.GetComponent<Rigidbody>();
        rigidbodyofnewtargetobjinlevel3.velocity = new Vector3(1f, 0f, -1f);
       // ce = ge.GetComponent<Rigidbody>();
      //  ce.velocity = new Vector3(-1f, 0f, 1f);
        
       
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        int limiter = 1;
        int loopCap =8;
        //yield on a new YieldInstruction that waits for 5 seconds.
        while (limiter < loopCap)
        {
            yield return StartCoroutine(keepconstvelinlvl3(10f, x));
            yield return StartCoroutine(ShowMessage("You are given 5 seconds to hit the target now", 3f));
            yield return StartCoroutine(PauseGame(5f,x));
            yield return StartCoroutine(Colorchangeinlvl3(3f));
            Vector3 holdr = rb.velocity / rb.velocity.magnitude;
            //  Vector3 tempVect = new Vector3(x, y * 0, z );
            rb.velocity = holdr * x;
            Debug.Log(rb.velocity.magnitude);
            Vector3 holdrb = trb.velocity / trb.velocity.magnitude;
            // Vector3 temprb = new Vector3(x , y * 0, c);
            trb.velocity = holdrb * x;
            // Vector3 temprb1 = new Vector3(c, y * 0, z);          
            // Vector3 temprb2 = new Vector3(c, y * 0, c);
            //Vector3 holdr2 = rb2.velocity / rb2.velocity.magnitude;
          //  rb2.velocity = holdr2 * x;
          //  Vector3 clr = cl.velocity / cl.velocity.magnitude;
           // cl.velocity = clr * x;
          //  Vector3 cer = ce.velocity / ce.velocity.magnitude;
          //  ce.velocity = cer * x;
            Vector3 dircompofnewTargetobjinlevel2 = rigbodyofnewTargetobjinlevel2.velocity / rigbodyofnewTargetobjinlevel2.velocity.magnitude;
            rigbodyofnewTargetobjinlevel2.velocity = dircompofnewTargetobjinlevel2 * x;
            rigidbodyoffalsetarget2.velocity = rigidbodyoffalsetarget2.velocity.normalized * x;
            Vector3 dircompofnewtargetobjinlevel3 = rigidbodyofnewtargetobjinlevel3.velocity / rigidbodyofnewtargetobjinlevel3.velocity.magnitude;
            rigidbodyofnewtargetobjinlevel3.velocity = dircompofnewtargetobjinlevel3 * x;
            //  c--;
            if (limiter == 1)
            {
                x += 2;
                limiter++;
                continue;
            }
            x +=3;
            //  y++;
            //  z++;
           // if (limiter == 3)
           // {
           //     newTargetobjinlevel3.GetComponent<Renderer>().material.color = new Color(0.7710f, 0.9339f, 0.1533f, 1f);
           //     newTargetobjinlevel2.GetComponent<Renderer>().material.color = new Color(0.7710f, 0.9339f, 0.1533f, 1f);
           //     Targeted.GetComponent<Renderer>().material.color = new Color(0.7710f, 0.9339f, 0.1533f, 1f);
           // }
            limiter++;
        }
        ScoreManager.instance.AddLevel(level);
        level++;
        ScoreManager.instance.refreshchance();
        StartCoroutine(level4(1f));
        //  Time.timeScale = 0f;

        //After we have waited 5 seconds print the time again.

        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
    IEnumerator level4(float x)
    {
        //Print the time of when the function is first called.
       
        Debug.Log("level4 says i am here");
 
        newTargetobjinlevel4.SetActive(true);
        yield return StartCoroutine(Colorchangeinlvl4(3f));
        rigidbodyofnewtargetobjinlevel4 = newTargetobjinlevel4.GetComponent<Rigidbody>();
        rigidbodyofnewtargetobjinlevel4.velocity = new Vector3(-1f, 0f, 1f);

        rigidbodyoffalsetarget2.velocity = rigidbodyoffalsetarget2.velocity.normalized * x;


        
       
      
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        int limiter = 1;
        int loopCap = 8;
        //yield on a new YieldInstruction that waits for 5 seconds.
        while (limiter < loopCap)
        {
            yield return StartCoroutine(keepconstvelinlvl4(10f, x));
            yield return StartCoroutine(ShowMessage("You are given 5 seconds to hit the target now", 3f));
            yield return StartCoroutine(PauseGame(5f,x));

            yield return StartCoroutine(Colorchangeinlvl4(3f));
            Vector3 holdr = rb.velocity / rb.velocity.magnitude;
            //  Vector3 tempVect = new Vector3(x, y * 0, z );
            rb.velocity = holdr * x;
            Debug.Log(rb.velocity.magnitude);
            Vector3 holdrb = trb.velocity / trb.velocity.magnitude;
            // Vector3 temprb = new Vector3(x , y * 0, c);
            trb.velocity = holdrb * x;
            rigidbodyoffalsetarget2.velocity = rigidbodyoffalsetarget2.velocity.normalized * x;
            // Vector3 temprb1 = new Vector3(c, y * 0, z);          
            // Vector3 temprb2 = new Vector3(c, y * 0, c);
            //Vector3 holdr2 = rb2.velocity / rb2.velocity.magnitude;
            //  rb2.velocity = holdr2 * x;
            // Vector3 clr = cl.velocity / cl.velocity.magnitude;
            // cl.velocity = clr * x;
            // Vector3 cer = ce.velocity / ce.velocity.magnitude;
            //  ce.velocity = cer * x;
            Vector3 dircompofnewTargetobjinlevel2 = rigbodyofnewTargetobjinlevel2.velocity / rigbodyofnewTargetobjinlevel2.velocity.magnitude;
            rigbodyofnewTargetobjinlevel2.velocity = dircompofnewTargetobjinlevel2 * x;
            Vector3 dircompofnewtargetobjinlevel3 = rigidbodyofnewtargetobjinlevel3.velocity / rigidbodyofnewtargetobjinlevel3.velocity.magnitude;
            rigidbodyofnewtargetobjinlevel3.velocity = dircompofnewtargetobjinlevel3 * x;
            Vector3 dircompofnewtargetobjinlevel4 = rigidbodyofnewtargetobjinlevel4.velocity / rigidbodyofnewtargetobjinlevel4.velocity.magnitude;
            rigidbodyofnewtargetobjinlevel4.velocity = dircompofnewtargetobjinlevel4 * x;
           // Vector3 dircompofnewfalseobjinlevel4 = rigidbodyofnewfalseobjinlevel4.velocity / rigidbodyofnewfalseobjinlevel4.velocity.magnitude;
          //  rigidbodyofnewfalseobjinlevel4.velocity = dircompofnewfalseobjinlevel4 * x;
            //  c--;
            if (limiter == 1)
            {
                x += 2;
                limiter++;
                continue;
            }
            x += 3;
            //  y++;
            //  z++;
           
            limiter++;
        }


       

        //After we have waited 5 seconds print the time again.

        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        ScoreManager.instance.AddLevel(level);
        level++;
        ScoreManager.instance.refreshchance();
        StartCoroutine(level5(1f));
    }
    IEnumerator level5(float x)
    {
        //Print the time of when the function is first called.
     
        Debug.Log("level5 says i am here");
      
        newTargetobjinlevel5.SetActive(true);
        yield return StartCoroutine(Colorchangeinlvl5(3f));

        rigidbodyofnewtargetobjinlevel5 = newTargetobjinlevel5.GetComponent<Rigidbody>();
        rigidbodyofnewtargetobjinlevel5.velocity = new Vector3(-1f, 0f, 1f);

        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        int limiter = 1;
        int loopCap = 8;
        //yield on a new YieldInstruction that waits for 5 seconds.
        while (limiter < loopCap)
        {
            yield return StartCoroutine(keepconstvelinlvl5(10f, x));
            yield return StartCoroutine(ShowMessage("You are given 5 seconds to hit the target now", 3f));
            yield return StartCoroutine(PauseGame(5f,x));
            yield return StartCoroutine(Colorchangeinlvl5(3f));
            Vector3 holdr = rb.velocity / rb.velocity.magnitude;
            //  Vector3 tempVect = new Vector3(x, y * 0, z );
            rb.velocity = holdr * x;
            rigidbodyoffalsetarget2.velocity = rigidbodyoffalsetarget2.velocity.normalized * x;
            Debug.Log(rb.velocity.magnitude);
            Vector3 holdrb = trb.velocity / trb.velocity.magnitude;
            // Vector3 temprb = new Vector3(x , y * 0, c);
            trb.velocity = holdrb * x;
            // Vector3 temprb1 = new Vector3(c, y * 0, z);          
            // Vector3 temprb2 = new Vector3(c, y * 0, c);
            //Vector3 holdr2 = rb2.velocity / rb2.velocity.magnitude;
            //  rb2.velocity = holdr2 * x;
          
            Vector3 dircompofnewTargetobjinlevel2 = rigbodyofnewTargetobjinlevel2.velocity / rigbodyofnewTargetobjinlevel2.velocity.magnitude;
            rigbodyofnewTargetobjinlevel2.velocity = dircompofnewTargetobjinlevel2 * x;
            Vector3 dircompofnewtargetobjinlevel3 = rigidbodyofnewtargetobjinlevel3.velocity / rigidbodyofnewtargetobjinlevel3.velocity.magnitude;
            rigidbodyofnewtargetobjinlevel3.velocity = dircompofnewtargetobjinlevel3 * x;
            Vector3 dircompofnewtargetobjinlevel4 = rigidbodyofnewtargetobjinlevel4.velocity / rigidbodyofnewtargetobjinlevel4.velocity.magnitude;
            rigidbodyofnewtargetobjinlevel4.velocity = dircompofnewtargetobjinlevel4 * x;
              Vector3 dircompofnewtargetobjinlevel5 = rigidbodyofnewtargetobjinlevel5.velocity / rigidbodyofnewtargetobjinlevel5.velocity.magnitude;
            rigidbodyofnewtargetobjinlevel5.velocity = dircompofnewtargetobjinlevel5 * x;
            //  c--;
            if (limiter == 1)
            {
                x += 2;
                limiter++;
                continue;
            }
            x += 3;
            //  y++;
            //  z++;
          
            limiter++;
        }


        Time.timeScale = 0f;

        //After we have waited 5 seconds print the time again.

        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

    private Vector3 RandomVector(float min, float max)
    {
      var x = Random.Range(min, max);
        var y = 0f;
        var z = Random.Range(min, max);
      return new Vector3(x, y, z);
    }

    
}
