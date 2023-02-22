
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
public class Try : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    private Rigidbody trb;
    private Rigidbody rb1;
   
    private Rigidbody cl;
    private Rigidbody ce;
    public GameObject Sphere;
    public GameObject go;
    public GameObject ge;
    public GameObject Targeted;
    public GameObject newTargetobjinlevel2;
    public GameObject newTargetobjinlevel3;
    int level = 1;
    // [SerializeField] BoxCollider col;
   

    void Start()
    {
        Sphere = GameObject.Find("Sphere");
        Targeted = GameObject.Find("Target");
        go = GameObject.Instantiate(Sphere);
        newTargetobjinlevel2 = GameObject.Instantiate(Targeted);
        go.SetActive(false);
        newTargetobjinlevel2.SetActive(false);
        GameObject ge = GameObject.Instantiate(Sphere);
        GameObject newTargetobjinlevel3 = GameObject.Instantiate(Targeted);
        ge.SetActive(false);
        newTargetobjinlevel3.SetActive(false);
        Invoke("feedDog", 5);
        StartCoroutine(level3(1f));
    }
    void Update()
    {
        Sphere.transform.eulerAngles = new Vector3(
    Sphere.transform.eulerAngles.x,
    Mathf.Clamp(Sphere.transform.eulerAngles.y, -90f, 90f),
    Sphere.transform.eulerAngles.z
);
       // Sphere1.transform.eulerAngles = new Vector3(
  // Sphere1.transform.eulerAngles.x,
  // Mathf.Clamp(Sphere1.transform.eulerAngles.y, -90f, 90f),
 //  Sphere1.transform.eulerAngles.z
//);

        // Sphere.transform.eulerAngles.y= Mathf.Clamp(Sphere.transform.eulerAngles.y, -90f, 90f);
    }

    void OnCollisionEnter(Collision collision)
    {
        
       // if (collision.gameObject.name == "Cube")
       // {
         
        //if (rb.velocity.y >= 0)
        // {
      //  reflectedObject.position = Vector3.Reflect(originalObject.position, Vector3.right);
        Vector3 tempVect = new Vector3(rb.velocity.x * -1, rb.velocity.y , rb.velocity.z );
                rb.velocity = tempVect;
          //  }
          //  else
          //  {
          //      Vector3 tempVect = new Vector3(rb.velocity.x * -1, rb.velocity.y*-1, rb.velocity.z * -1);
           //     rb.velocity = tempVect;
          //  }

           
       // }
    }

  
   public  void feedDog()
    {
         Debug.Log("Now feeding Dog");
        //    rb = gameObject.GetComponent<Rigidbody>();
       
      
       
       // Sphere2=GameObject.Find("Sphere2");
       
     //   rb2= Sphere2.GetComponent<Rigidbody>();
        trb= Targeted.GetComponent<Rigidbody>();
        rb = Sphere.GetComponent<Rigidbody>();
     
        rb.velocity =new Vector3(1f,0f,1f);
       
      //  rb2.velocity = new Vector3(-1f, 0f, 1f);
        trb.velocity = new Vector3(1f, 0f, 1f);
        var x = 1f;
       
       
            StartCoroutine(level1(x));
      

    }

   IEnumerator level1(float x)
    {
        //Print the time of when the function is first called.
        bool coroutineOver = false;
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        int limiter = 1;
        int loopCap = 8;
        //yield on a new YieldInstruction that waits for 5 seconds 
      while (limiter < loopCap)
            {
                yield return new WaitForSeconds(1);
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
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        // StartPause();
      
        ScoreManager.instance.AddLevel(level);
        level++;
        go.SetActive(true);
        newTargetobjinlevel2.SetActive(true);

        newTargetobjinlevel2.GetComponent<Renderer>().material.color = Color.white;
        Targeted.GetComponent<Renderer>().material.color = Color.white;
        coroutineOver = true;
        StartCoroutine(level2(1f));
        yield return null;

       // displayset();
    }
    // public void StartPause2(GameObject newTargetobjinlevel2)
    // {
    // how many seconds to pause the game

    //    StartCoroutine(PauseGame2(7f, newTargetobjinlevel2));
    // }
    //  GameObject newTargetobjinlevel3;
    //  GameObject ge;
    //  public IEnumerator PauseGame2(float pauseTime,GameObject newTargetobjinlevel2)
    // // {
    //    Debug.Log("Inside PauseGame()");
    //     
    //   Time.timeScale = 0f;
    //   float pauseEndTime = Time.realtimeSinceStartup + pauseTime-2;
    //    while (Time.realtimeSinceStartup < pauseEndTime)
    //    {
    //        yield return 0;
    //    }


    //    Debug.Log("Done with my pause");
    //    pauseTime = 2f;


    //Time.timeScale = 0f;
    //   StartCoroutine(level2(1f));
    //  Time.timeScale = 0f;
    //   pauseEndTime = Time.realtimeSinceStartup + pauseTime;
    //   while (Time.realtimeSinceStartup < pauseEndTime)
    //   {
    //       yield return 0;
    //   }
    //  Time.timeScale = 1f;
    //  Time.timeScale = 1f;

    //  PauseEnded2(ge, newTargetobjinlevel3);
    //  StartCoroutine(Displaybeforenextlevel2(2f));

    //  }
    // public IEnumerator Displaybeforenextlevel2(float pauseTime)

    //  {

    //   Debug.Log("Inside displayame()");
    //   Time.timeScale = 0f;
    //   float pauseEndTime = Time.realtimeSinceStartup + pauseTime;
    // while (Time.realtimeSinceStartup < pauseEndTime)
    // {
    //     yield return 0;
    //  }
    //  Time.timeScale = 1f;
    //  Debug.Log("Done with my display");



    //   StartCoroutine(level2(1f));
    //  newTargetobjinlevel3.GetComponent<Renderer>().material.color = new Color(0.7710f, 0.9339f, 0.1533f, 1f);
    //  newTargetobjinlevel2.GetComponent<Renderer>().material.color = new Color(0.7710f, 0.9339f, 0.1533f, 1f);
    //  Targeted.GetComponent<Renderer>().material.color = new Color(0.7710f, 0.9339f, 0.1533f, 1f);
    //  PauseEnded2(ge,newTargetobjinlevel3);
    // }
    //public void PauseEnded2(GameObject ge, GameObject newTargetobjinlevel3)
    // {
    //     ScoreManager.instance.AddLevel(level);
    //     level++;

    //StartCoroutine(level3(1f, ge, newTargetobjinlevel3));


    //  }

    // public IEnumerator Displaybeforenextlevel(float pauseTime, GameObject go, GameObject newTargetobjinlevel2)
    // {

    //    Debug.Log("Inside displayame()");
    //   Time.timeScale = 0f;
    //   float pauseEndTime = Time.realtimeSinceStartup + pauseTime;
    //   while (Time.realtimeSinceStartup < pauseEndTime)
    //   {
    //      yield return 0;
    //  }
    //   Time.timeScale = 1f;
    //   Debug.Log("Done with my display");




    //   StartCoroutine(level2(1f));
    //    newTargetobjinlevel2.GetComponent<Renderer>().material.color = new Color(0.7710f, 0.9339f, 0.1533f, 1f);
    //    Targeted.GetComponent<Renderer>().material.color = new Color(0.7710f, 0.9339f, 0.1533f, 1f);
    //   PauseEnded(go, newTargetobjinlevel2);
    //PauseEnded();
    //   }
   
    void displayset()
    {
        go.SetActive(true);
        newTargetobjinlevel2.SetActive(true);

        newTargetobjinlevel2.GetComponent<Renderer>().material.color = Color.white;
        Targeted.GetComponent<Renderer>().material.color = Color.white;
        StartCoroutine(level2(1f));
    }

    IEnumerator level2(float x)
    {
        //Print the time of when the function is first called.
        yield return level1(1f);
        bool coroutineOver = false;
        Rigidbody rigbodyofnewTargetobjinlevel2 = newTargetobjinlevel2.GetComponent<Rigidbody>();
     cl=   go.GetComponent<Rigidbody>();
    cl.velocity = new Vector3(1f, 0f, -1f);
        rigbodyofnewTargetobjinlevel2.velocity = new Vector3(1f, 0f, -1f);
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        int limiter = 1;

        int loopCap = 8;
        //yield on a new YieldInstruction that waits for 5 seconds.

        while (limiter < loopCap)
        {
            yield return new WaitForSeconds(1);
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

            Vector3 clr=cl.velocity/cl.velocity.magnitude;
    cl.velocity=clr* x;
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
         
            if (limiter == 3)
            {
                newTargetobjinlevel2.GetComponent<Renderer>().material.color = new Color(0.7710f, 0.9339f, 0.1533f, 1f);
                Targeted.GetComponent<Renderer>().material.color = new Color(0.7710f, 0.9339f, 0.1533f, 1f);
            }
            limiter++;
        }
        //After we have waited 5 seconds print the time again.

        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        //StartPause2(newTargetobjinlevel2);
        ScoreManager.instance.AddLevel(level);
        level++;
        coroutineOver = true;
        displayset2();
    }
    void displayset2()
    {
        
        ge.SetActive(true);
        newTargetobjinlevel3.SetActive(true);
        newTargetobjinlevel3.GetComponent<Renderer>().material.color = Color.white;
        newTargetobjinlevel2.GetComponent<Renderer>().material.color = Color.white;
        Targeted.GetComponent<Renderer>().material.color = Color.white;
        StartCoroutine(level3(1f));
    }
    IEnumerator level3(float x)
    {
        //Print the time of when the function is first called.
        yield return level2(1f);
        Rigidbody rigidbodyofnewtargetobjinlevel3= newTargetobjinlevel3.GetComponent<Rigidbody>();
        rigidbodyofnewtargetobjinlevel3.velocity = new Vector3(-1f, 0f, 1f);
        ce = ge.GetComponent<Rigidbody>();
        ce.velocity = new Vector3(-1f, 0f, 1f);
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        int limiter = 1;
        int loopCap =8;
        //yield on a new YieldInstruction that waits for 5 seconds.
        while (limiter < loopCap)
        {
            yield return new WaitForSeconds(1);
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
            Vector3 clr = cl.velocity / cl.velocity.magnitude;
            cl.velocity = clr * x;
            Vector3 cer = ce.velocity / ce.velocity.magnitude;
            ce.velocity = cer * x;
            //Vector3 dircompofnewTargetobjinlevel2 = rigbodyofnewTargetobjinlevel2.velocity / rigbodyofnewTargetobjinlevel2.velocity.magnitude;
            //rigbodyofnewTargetobjinlevel2.velocity = dircompofnewTargetobjinlevel2 * x;
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
            if (limiter == 3)
            {
                newTargetobjinlevel3.GetComponent<Renderer>().material.color = new Color(0.7710f, 0.9339f, 0.1533f, 1f);
                newTargetobjinlevel2.GetComponent<Renderer>().material.color = new Color(0.7710f, 0.9339f, 0.1533f, 1f);
                Targeted.GetComponent<Renderer>().material.color = new Color(0.7710f, 0.9339f, 0.1533f, 1f);
            }
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
