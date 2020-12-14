using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotShell : MonoBehaviour
{
    public float shotSpeed;

    [SerializeField]
    private GameObject shellPrefab = null;
    //SerializeFieldにするとprivateでもInspector上から設定できる

    [SerializeField]
    private AudioClip shotSound = null;

    private float timeBetweenShot = 0.75f;
    private float timer;

    public int shotCount;

    public int tripleshotCount;

    [SerializeField]
    private Text shellLabel;

    public int shotMaxCount = 20;

    [SerializeField]
    private Text tripleshellLabel;


    // Start is called before the first frame update
    void Start()
    {
        shellLabel.text = "砲弾:" + shotCount;

        shotCount = shotMaxCount;
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space) && timer > timeBetweenShot && shotCount > 0)//もしスペースキーが押されたら
        {
            timer = 0.0f;

            shotCount -= 1;

            shellLabel.text = "砲弾:" + shotCount;

            GameObject shell = Instantiate(shellPrefab, transform.position, Quaternion.identity);
            //shellPrefabとtransformのpositionの値とQuaternionのidentity(無回転のQuarternion)をInstantiateメソッドで受け取ってshellに代入する

            Rigidbody shellRb = shell.GetComponent<Rigidbody>();

            shellRb.AddForce(transform.forward * shotSpeed);
            //shellRb変数にAddForceメソッドを使う、forward(0,0,1)

            Destroy(shell, 3.0f);
            //shellを三秒後に破壊する

            AudioSource.PlayClipAtPoint(shotSound, transform.position);
            //shotSoundを流す

        }

        TripleShell();
    }

    public void AddShell(int amount)
    {
        shotCount += amount;

        if(shotCount > shotMaxCount)
        {
            shotCount = shotMaxCount;
        }

        shellLabel.text = "砲弾:" + shotCount;
    }

    public void TripleShell()//TrpleShellItemに送る
                                       //上のUpdateメソッドを参考に作った
                                       //イメージは三方向に球が飛んでいく
    {
        if (Input.GetKeyDown(KeyCode.T) && timer > timeBetweenShot && shotCount > 0) 
        {
            timer = 0.0f;

            tripleshotCount -= 1;

            //tripleshellLabel.text = "砲弾" + tripleshotCount;

            
            GameObject shell = Instantiate(shellPrefab, transform.position, Quaternion.identity);

            Rigidbody shellRb = shell.GetComponent<Rigidbody>();

            shellRb.AddForce((transform.forward + transform.right) * shotSpeed);

            Destroy(shell, 3.0f);


            GameObject shell1 = Instantiate(shellPrefab, transform.position, Quaternion.identity);

            Rigidbody shellRb1 = shell1.GetComponent<Rigidbody>();

            shellRb1.AddForce(transform.forward * shotSpeed);

            Destroy(shell, 3.0f);

            

            GameObject shell2 = Instantiate(shellPrefab, transform.position, Quaternion.identity);

            Rigidbody shellRb2 = shell2.GetComponent<Rigidbody>();

            shellRb2.AddForce((transform.forward - transform.right) * shotSpeed);

            Destroy(shell, 3.0f);




        }
    }
    public void AddTripleShotShell(int amount)
    {
        tripleshotCount += amount;
    }
}
