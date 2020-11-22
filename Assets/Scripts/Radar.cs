using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))//もし他のオブジェクトに「Player」というタグが付いていたら
        {
            transform.root.LookAt(target);
            //「root」を使うと「親（最上位の親）」の情報を取得することができる
            //LookAt()メソッドは指定した方向にオブジェクトの向きを回転させることができる

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
