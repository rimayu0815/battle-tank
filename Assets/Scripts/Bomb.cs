using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bomb : MonoBehaviour
{
    [SerializeField]
    private GameObject effectPrefab;

    [SerializeField]
    private AudioClip sound;

    private float power = 5f;

    private float radius = 5f;

    private BoxCollider boxCol;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("Explode", 5f);

        boxCol = GetComponent<BoxCollider>();

        boxCol.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Explode()
    {
        boxCol.enabled = true;



        //GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");

        //if (cubes.Length == 0) return;

        //foreach(GameObject cube in cubes)
        //{
        //if(cube.GetComponent<Rigidbody>())
        //{
        // cube.GetComponent<Rigidbody>().AddExplosionForce(power, transform.position, radius, 1.0f, ForceMode.Impulse);

        // Destroy(gameObject);
        //}
        //}
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject);

        if (other.gameObject.name == "Ground")
        {
            return;
        }

        if (other.gameObject.name == "Mine")
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.TryGetComponent(out UnityEngine.AI.NavMeshAgent navi) == true)
        {
            //Destroy(navi);
            //navi.enabled = false;
        }

        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();

        if (rb == null)
        {
            other.gameObject.AddComponent<Rigidbody>();

            rb = other.gameObject.GetComponent<Rigidbody>();
        }
        rb.AddExplosionForce(power, transform.position, radius, 1.0f, ForceMode.VelocityChange);

        Destroy(gameObject);
   
    }
}
