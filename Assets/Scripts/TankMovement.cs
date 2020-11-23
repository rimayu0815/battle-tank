using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;

    private Rigidbody rb;
    private float movementInputValue;
    private float turnInputValue;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //GetComponentメソッドを使ってRigidbodyコンポーネントを取得してrb変数に代入する
    }

    // Update is called once per frame
    void Update()
    {
        TankMove();
        TankTurn();
    }

    void TankMove()//前進後退のメソッド
    {
        movementInputValue = Input.GetAxis("Vertical");
        //GetAxisメソッドでVertical(上下キー、w,s)の入力を受け取り、その値をmovementInputValueへと代入する
        //Horizontalは水平
       
        Vector3 movement = transform.forward * movementInputValue * moveSpeed * Time.deltaTime;
        //Time.deltaTimeとは緒空前のフレームと今のフレーム間で経過した時間を返すプロパティ
        //transform.forward都は単位ベクトルVector3(0,0,1)とゲームオブジェクトの持つ回転をかけたもの

        rb.MovePosition(rb.position + movement);
        //rb変数のpositionの値とVector3 movementの値を足して値がrb変数のMovePositionの値となる

    }

    void TankTurn()//旋回のメソッド
    {
        turnInputValue = Input.GetAxis("Horizontal");
        //GetAxisメソッドでHorizontal(左右キー、a,d)の入力を受けとり、その値をturnInputValueへと代入する
        //Verticalは垂直

        float turn = turnInputValue * turnSpeed * Time.deltaTime;

        Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
        //Quaternion型のEuler角をQuartenion型のturnRotation変数に代入
        //Quartenion.Eulerで三つの角度を指定
        //Quartenionは四元数とも言われ任意軸回転が可能、回転させる際に使用する数

        rb.MoveRotation(rb.rotation * turnRotation);

    }
}
