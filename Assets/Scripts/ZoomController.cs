using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomController : MonoBehaviour
{
    private Camera cam;
    private float zoom;
    private float view;
        
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        view = cam.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        cam.fieldOfView = view + zoom;

        if(cam.fieldOfView < 20f)//ズームアップの上限値を定める
        {
            cam.fieldOfView = 20f;
        }

        if(cam.fieldOfView > 60f)//元の位置を定める
        {
            cam.fieldOfView = 60f;
        }

        if(Input.GetKey(KeyCode.RightShift))//実際にどのキーを割り当てるかは自由です
        {
            zoom -= 1.2f;//どれくらいのスピードでズームアップするか
            
            if(zoom < -40f)//-40を超えたら
            {
                zoom = -40f;//zoomを-40
            }
        }
        else
        {
            zoom += 1.2f;

            if(zoom>0)
            {
                zoom = 0;
            }
        }

        print("zoomの値" + zoom);
    }
}
