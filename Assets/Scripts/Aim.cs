using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Aim : MonoBehaviour
{
    [SerializeField]
    private Image aimImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);//レーザーを（ray）飛ばす起点と方向

        Debug.DrawRay(transform.position, transform.forward * 60, Color.green);//レーザーの光を可視化

        RaycastHit hit;//rayの当たり判定の情報を入れる箱

        if(Physics.Raycast(ray, out hit, 60))
        {
            string hitName = hit.transform.gameObject.tag;

            if(hitName == "Enemy")
            {
                aimImage.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);//照準器の色を赤に変える
            }
            else
            {
                aimImage.color = new Color(0.0f, 1.0f, 1.0f, 1.0f);//照準器の色を青に変える
            }
        }
        else
        {
            aimImage.color = new Color(0.0f, 1.0f, 1.0f, 1.0f);//照準器の色を青に変える
        }
    }
}
