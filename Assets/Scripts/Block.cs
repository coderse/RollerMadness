using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private bool isColided = false;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isColided == false && gameObject.tag == "Player")
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            scoreManager.score--;
            isColided = true;  

        }

       


    }
}
