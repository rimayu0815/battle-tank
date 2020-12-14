﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField]
    private GameObject effectPrefab;

    [SerializeField]
    private GameObject effectPrefab2;

    public int objectHP;

    [SerializeField]
    private GameObject[] itemPrefab;

    private int number;

    [SerializeField]
    private int Getpoint;

 
    //[SerializeField]
    //private GameObject HPItemPrefab;

    //[SerializeField]
    //private GameObject StopAttackItemPrefab;

    private void OnTriggerEnter(Collider other)
    //接触したオブジェクトが引数otherとして渡される
    {
        if(other.CompareTag("Shell"))
        //接触したオブジェクトのタグが"Shell"の時
        {
            objectHP -= 1;

            if (objectHP > 0)
            {

                Destroy(other.gameObject);

                //GameObject effect = Instantiate(effectPrefab, other.transform.position, Quaternion.identity);
                //Destroy(effect, 2.0f);

            }


            else
            {
                Destroy(other.gameObject);

                //GameObject effect2 = Instantiate(effectPrefab2, other.transform.position, Quaternion.identity);
                //Destroy(effect2, 2.0f);

                Debug.Log("000");
                Destroy(this.gameObject);



                Debug.Log("111");
                number = Random.Range(0, itemPrefab.Length);
                Debug.Log("222");
                Instantiate(itemPrefab[number], transform.position, Quaternion.identity);
               

                

                FindObjectOfType<Score>().AddScore(Getpoint);//ScoreScriptのAddScoreメソッドをGetpoint変数を使用して実行する

                FindObjectOfType<GameClearController>().DecreseEnemy();

            }

        }

        if (other.CompareTag("EnemyShell"))
        //接触したオブジェクトのタグが"Shell"の時
        {
            Destroy(other.gameObject);

        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
