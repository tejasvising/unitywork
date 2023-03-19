using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TargetShooter : MonoBehaviour
{
 
    [SerializeField] Camera cam;
   // [SerializeField] TextMeshProUGUI scoreText;
   // int score = 0;
    // int score = 0;
  //  void Start()
  //  {
   //     scoreText.text = "Score:" + score.ToString();
  //  }
    void Update()
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
                Target target = hit.collider.gameObject.GetComponent<Target>();
                FalseTarget falsetarget = hit.collider.gameObject.GetComponent<FalseTarget>();
                if (falsetarget != null)
                {
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

                    ScoreManager.instance.AddPoint();
                }
            }
        }
        /*  if (Input.GetKeyDown(KeyCode.Mouse0))
           {

               Debug.Log("ab");
           }*/

    }
   
}
