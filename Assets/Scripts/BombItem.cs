using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombItem : MonoBehaviour
{

    [SerializeField]
    private AudioClip getSound;

    [SerializeField]
    private GameObject effectPrefab;
    private BombSetting bb;
    private int reward = 5;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            bb = GameObject.Find("Tank").GetComponent<BombSetting>();

            bb.AddBomb(reward);

            Destroy(gameObject);
        }
    }
}
