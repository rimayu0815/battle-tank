using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellItem : MonoBehaviour
{
    [SerializeField]
    private AudioClip getSound;

    [SerializeField]
    private GameObject effectPrefab;
    private ShotShell ss;
    private int reward = 5;//弾数をいくつ回復させるか


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Player")
        {
            ss = GameObject.Find("ShotShell").GetComponent<ShotShell>();
            //Find()メソッドは、「名前」でオブジェクトを探し特定します。
            //「ShotShell」オブジェクトを探し出して、それについている「ShotShell」スクリプトのデータを取得する
            //取得したデータをssに代入する

            ss.AddShell(reward);
            //ShotShellScriptの中に記載されている「AddShellメソッド」を呼び出す
            //rewardで設定した数値分だけ弾数が回復

            Destroy(gameObject);

            //AudioSource.PlayClipAtPoint(getSound, transform.position);

            //GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);

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
