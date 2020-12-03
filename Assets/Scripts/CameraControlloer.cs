using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlloer : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private Camera FPSCamera;

    private bool mainCameraON = true;
    //「bool」は「true」か「false」の二択の情報を扱うことができる

    
    [SerializeField]
    private AudioListener mainListener;
    [SerializeField]
    private AudioListener FPSListener;

    [SerializeField]
    private GameObject aimImage;


    // Start is called before the first frame update
    void Start()
    {
        mainCamera.enabled = true;
        FPSCamera.enabled = false;


        mainListener.enabled = true;
        FPSListener.enabled = false;

        aimImage.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C) && mainCameraON == true)//&&は論理関係の「かつ」という意味、「A && B」は「AかつB」
                                                               //「==」は「左右が等しい」という意味
                                                               //もし「Cボタン」を押したとき、「かつ」、「mainCameraON」の状態が「true」の時
        {
            mainCamera.enabled = false;
            FPSCamera.enabled = true;

            mainCameraON = false;


            mainListener.enabled = false;
            FPSListener.enabled = true;

            aimImage.SetActive(true);
        }

        else if(Input.GetKeyDown(KeyCode.C) &&mainCameraON ==false)//もし「Cボタン」を押したとき、「かつ」、「mainCameraON」の状態が「false」の時
        {
            mainCamera.enabled = true;
            FPSCamera.enabled = false;

            mainCameraON = true;


            mainListener.enabled = true;
            FPSListener.enabled = false;

            aimImage.SetActive(false);
        }

    }
}
