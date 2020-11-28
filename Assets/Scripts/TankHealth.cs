using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    [SerializeField]
    public GameObject effectPrefab;

    [SerializeField]
    public GameObject effectPrefab2;
    public int tankHP;

    [SerializeField]
    private Text HPLabel;

    public int HPMax = 20; 


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "EnemyShell")
        {
            tankHP -= 1;

            HPLabel.text = "HP:" + tankHP;

            if (tankHP > 0) 
            {
                Destroy(other.gameObject);
                
                //GameObject effect = Instantiate(effectPrefab, other.transform.position, Quaternion.identity);
                //Destroy(effect, 1.0f);
                
            }

            else
            {
                Destroy(other.gameObject);

                //GameObject effect2 = Instantiate(effectPrefab2, other.transform.position, Quaternion.identity);
                //Destroy(effect, 1.0f);

                //Destroy(gameObject);

                this.gameObject.SetActive(false);
                //プレーヤーを破壊せずに画面から見えなくする
                //プレーヤーを破壊すると、その時点でメモリー上から消えるので、以降のコードが実行されなくなる

                Invoke("GoToGameOver", 1.5f);//1.5秒後に「GoToGameOver()」メソッドを実行する
            }
        }
    }

    void GoToGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
    
    public void AddHP(int amount)
    {
        tankHP += amount;

        if(tankHP >HPMax)
        {
            tankHP = HPMax;
        }

        HPLabel.text = "HP:" + tankHP;

    }

    // Start is called before the first frame update
    void Start()
    {
        HPLabel.text = "HP:" + tankHP;

        tankHP = HPMax; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
