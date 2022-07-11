using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    /* [SerializeField] private Vector3 movement; //private olsada inspectordan ulaþmaya yarar */
    private Vector3 movement;
    [SerializeField] public float speed =10f;
    [SerializeField] Rigidbody rigitbody;
    [SerializeField] private GameObject deadEffect;

    private TimeManager timeManager;

    void Start()
    {
        timeManager = FindObjectOfType<TimeManager>();
                
    }

    void Update()
    {
        if (timeManager.gameOver == false && timeManager.gameFinished == false)
        {
            MoveThePlayer();  
        }
        if (timeManager.gameOver || timeManager.gameFinished)
        {
            rigitbody.isKinematic = true;
        }



    }

    private void MoveThePlayer()
    {
        float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        movement = new Vector3(x, 0f, z);

        rigitbody.AddForce(movement);
    }

    private void OnDisable()
    {
        Instantiate(deadEffect, transform.position, transform.rotation);
    }
}
