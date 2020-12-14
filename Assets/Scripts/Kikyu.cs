using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kikyu: MonoBehaviour
{
    public GameObject target;

    public Quaternion startRotate;//機体を傾けさせずに向きだけを変える方法を模索した（①リセットしたらいけるかも）
                                  //結果向きが変わらない

    public Quaternion updateRotate;//タンクを見た時のｙ座標がほしいから　②
                                   //y座標だけを変更してほかの座標をリセットすればたぶんいける　②

    private int y ;//updateRotateのy座標をint型に変えるため  ②

    private Vector3 kikyuAngle;//気球の傾きを調整④　TurretController参照

    // Start is called before the first frame update
    void Start()
    {
        //startRotate = transform.rotation;//rotateの最初の位置を取得　①

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform);

        transform.eulerAngles = new Vector3(kikyuAngle.x, transform.root.eulerAngles.y, 0);//④

        if(kikyuAngle.x < 1)
        {
            kikyuAngle.x = 0f;
        }

        //if (transform.localEulerAngles.x >= 0)//角度をいじる③
        //{
            //transform.Rotate(new Vector3(-30.0f, y,0));
        //}
        //Debug.Log(transform.rotation);


        //updateRotate.y = transform.rotation.y;// ②

        //transform.rotation = Quaternion.Euler(0, updateRotate.y, 0);//②

        HeliMove();

        //y = (int)updateRotate.y;

        
        //Debug.Log("111");

        //transform.rotation = startRotate;//rotateをリセット（タイミングなども考えてみる）　①   
        //Debug.Log("222");


    }

    void HeliMove()
    {

        if (transform.position.y < 5f)
        {
            transform.Translate(Vector3.up * Time.deltaTime * 1);
        }


        if (Vector3.Distance(transform.position, target.transform.position) > 10f)
        {
            //transform.LookAt(target.transform);

            //transform.rotation = startRotate;//rotateをリセット（タイミングなども考えてみる）　①

            transform.Translate(Vector3.forward * Time.deltaTime * 1);
        }

    }
}
