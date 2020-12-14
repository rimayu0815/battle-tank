using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClearController : MonoBehaviour
{
    private GameObject[] enemyAll;

    private int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        enemyAll = GameObject.FindGameObjectsWithTag("Enemy");

        enemyCount = enemyAll.Length;

        Debug.Log(enemyAll.Length);
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyCount <= 0)
        {
            Invoke("GoToGameClear", 1.5f);
        }
        
    }

    public void DecreseEnemy()
    {
        enemyCount--;

        //enemyAll = new GameObject[GameObject.FindGameObjectsWithTag("Enemy").Length];
        //enemyAll = GameObject.FindGameObjectsWithTag("Enemy");

        Debug.Log(enemyCount);
    }

    void GoToGameClear()
    {
        SceneManager.LoadScene("GameClear");
    }
        
        
}
