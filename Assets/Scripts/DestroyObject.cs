using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    //接触したオブジェクトが引数otherとして渡される
    {
        if(other.CompareTag("Shell"))
        //接触したオブジェクトのタグが"Shell"の時
        {
            Destroy(this.gameObject);
            //このオブジェクトを破壊する

            Destroy(other.gameObject);
            //接触したオブジェクトを破壊する
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
