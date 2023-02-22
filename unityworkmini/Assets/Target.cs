using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public static Target Instance;
    void Start()
    {
  //var rb = gameObject.GetComponent<Target>();
  // rb.velocity = RandomVector(0f, 5f);
        Invoke("waitColorchange", 5);
        Debug.Log("color will change in 5 seconds");
      

    }

    public void waitColorchange()
    {
       // Debug.Log("Now feeding Dog");
        GetComponent<Renderer>().material.color = new Color(0.7710f, 0.9339f, 0.1533f, 1f); 
    }
    public void changeWhite()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }


    
    public void Hit() {
        
       transform.position = TargetBounds.Instance.GetRandomPosition();

    }
}
