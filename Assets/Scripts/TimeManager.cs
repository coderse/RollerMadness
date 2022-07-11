using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public bool gameFinished = false;
    public bool gameOver= false;
    [SerializeField] private float levelFinishTime = 5f;
    [SerializeField] private Text timeText;

    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private List<GameObject> destroyAfterGame = new List<GameObject>();

    void Start()
    {
        
    }

    void Update()
    {
        if (gameOver == false && gameFinished == false)
        {
            UpdateTheTimer();

        }


        if (Time.timeSinceLevelLoad >= levelFinishTime && gameOver == false)
        {
            gameFinished = true;
            winPanel.gameObject.SetActive(true);
            losePanel.gameObject.SetActive(false);
            UpdateObjectsList("Objects");
            UpdateObjectsList("Enemy");

            foreach (GameObject allobject in destroyAfterGame)
            {
                Destroy(allobject);
            } 

        }
        if (gameOver == true)
        {
            winPanel.gameObject.SetActive(false);
            losePanel.gameObject.SetActive(true);
            UpdateObjectsList("Objects");
            UpdateObjectsList("Enemy");
            foreach (GameObject allobject in destroyAfterGame)
            {
                Destroy(allobject);
            }
        }
    }

    private void UpdateObjectsList(string tag)
    {
        destroyAfterGame.AddRange(GameObject.FindGameObjectsWithTag(tag));
    }

    private void UpdateTheTimer()
    {
        timeText.text = "Time: " + (int)Time.timeSinceLevelLoad;
    }

    
}
