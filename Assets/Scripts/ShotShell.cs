using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space) && timer > timeBetweenShot && shotCount > 0)//もしスペースキーが押されたら
        {
            timer = 0.0f;

            shotCount -= 1;


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
    }
}
