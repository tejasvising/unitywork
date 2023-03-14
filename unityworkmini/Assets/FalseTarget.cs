using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalseTarget : MonoBehaviour
{
    // Start is called before the first frame update
    public static FalseTarget Instance;
    void Start()
    {

    }
    public void collide()
    {

        ScoreManager.instance.Chances();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
