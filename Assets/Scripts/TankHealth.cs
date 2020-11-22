using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHealth : MonoBehaviour
{
    [SerializeField]
    public GameObject effectPrefab;

    [SerializeField]
    public GameObject effectPrefab2;
    public int tankHP;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "EnemyShell")
        {
            tankHP -= 1;

            if (tankHP > 0) 
            {
                Destroy(other.gameObject);
                
                //GameObject effect = Instantiate(effectPrefab, other.transform.position, Quaternion.identity);
                //Destroy(effect, 1.0f);
                
            }

            else
            {
                Destroy(other.gameObject);

                //GameObject effect2 = Instantiate(effectPrefab2, other.transform.position, Quaternion.identity);
                //Destroy(effect, 1.0f);

                Destroy(gameObject);
            }
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
