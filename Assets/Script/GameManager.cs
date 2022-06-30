using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] grounds;
    private int currentLevel;
    
    public float groundsCount;
    void Start()
    {
        grounds = GameObject.FindGameObjectsWithTag("Ground");
        currentLevel = SceneManager.GetActiveScene().buildIndex;
    }


    void Update()
    {
        groundsCount = grounds.Length;
    }

    
    public void NextLevel()
    {
        SceneManager.LoadScene(currentLevel + 1); //mevcut sahneden sonraki sahneye gecis

    }
}
