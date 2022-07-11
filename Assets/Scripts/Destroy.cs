using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] private float time = 3f;
    void Start()
    {
        Destroy(gameObject, time);
    }

    void Update()
    {
        
    }
}
