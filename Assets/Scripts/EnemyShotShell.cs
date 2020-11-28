using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotShell : MonoBehaviour
{
    public float shotSpeed;

    [SerializeField]
    private GameObject enemyShellPrefab;

    [SerializeField]
    private AudioClip shotSound;
    private int interval;

    public float stopTimer = 5.0f;


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

        if (interval %50  == 0 && stopTimer<= 0)//発射の間隔
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
    }
}
