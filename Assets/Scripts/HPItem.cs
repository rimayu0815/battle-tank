using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPItem : MonoBehaviour
{
    [SerializeField]
    private AudioClip getSound;

    [SerializeField]
    private GameObject effectPrefab;
    private TankHealth th;
    private int reward = 5;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Player")
        {
            th = GameObject.Find("Tank").GetComponent<TankHealth>();

            th.AddHP(reward);

            Destroy(gameObject);

            //GameObject effct = Instantiate(effectPrefab, transform.position, Quaternion.identity);

            //Destroy(effectPrefab, 0.5f);

            //AudioSource.PlayClipAtPoint(getSound, transform.position);
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
