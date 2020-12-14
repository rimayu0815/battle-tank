using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField]
    private GameObject effectPrefab;

    [SerializeField]
    private AudioClip sound;

    private float power = 10f;

    private float radius = 10f;


    private void OnCollisionEnter(Collision collision)
    {
        //GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);

        //Destroy(effect, 0.5f);
        //AudioSource.PlayClipAtPoint(sound, transform.position);

        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();//タンクのRigidbodyを取得する

        rb.AddExplosionForce(power, transform.position, radius, 1.0f, ForceMode.VelocityChange);//タンクのRigidbodyに爆発の力を加える
                                                                                                //ForceMode.VelocityChange・・・>質量を無視して、瞬間的に速度を変化させる

        Destroy(gameObject);//地雷を破壊する

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
