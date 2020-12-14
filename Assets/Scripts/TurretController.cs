﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    private Vector3 angle;
    private AudioSource audioS;

    // Start is called before the first frame update
    void Start()
    {

        angle = transform.eulerAngles;//Turretの最初の角度を取得する

        //audioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.P))
        {
            //audioS.enabled = true;

            angle.x -= 0.5f;

            transform.eulerAngles = new Vector3(angle.x, transform.root.eulerAngles.y, 0);
            //親の「旋回角度」に合わせるのが「transform.root.eulerAngles.y」の部分

            if(angle.x < 50)
            {
                angle.x = 50;
            }

        }
        else if(Input.GetKey(KeyCode.L))
        {
            //audioS.enabled = true;

            angle.x += 0.5f;
            
            transform.eulerAngles = new Vector3(angle.x, transform.root.eulerAngles.y, 0);
            
            if(angle.x > 90)
            {
                angle.x = 90;
            }
        }
        else 
        {
            //audioS.enabled = false;
        }
    }
}
