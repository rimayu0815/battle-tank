using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyShotShell : MonoBehaviour
{
    public float shotSpeed;

    [SerializeField]
    private GameObject enemyShellPrefab;

    [SerializeField]
    private AudioClip shotSound;
    private int interval;

    public float stopTimer = 5.0f;

    [SerializeField]
    private Text stopLabel;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame50
    void Update()
    {
        interval += 1;

        stopTimer -= Time.deltaTime;

        if(stopTimer < 0)
        {
            stopTimer = 0;
        }

        stopLabel.text = "" + stopTimer.ToString("0");//小数点以下は切り捨て

        if (interval %200  == 0 && stopTimer<= 0)//発射の間隔
        {
            GameObject enemyShell = Instantiate(enemyShellPrefab, transform.position, Quaternion.identity);

            Rigidbody enemyShellRb = enemyShell.GetComponent<Rigidbody>();

            enemyShellRb.AddForce(transform.forward * shotSpeed);

            Destroy(enemyShell, 3.0f);

            AudioSource.PlayClipAtPoint(shotSound, transform.position);


        }


    }

    public void AddStopTimer(float amount)//敵の攻撃をストップさせるメソッド
    {
        stopTimer += amount;

        stopLabel.text = "" + stopTimer.ToString("0");
    }
}
