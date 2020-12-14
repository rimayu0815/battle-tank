using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShellItem : MonoBehaviour//ShellItemと似たようなイメージで作った
{
    [SerializeField]
    private AudioClip getSound;

    [SerializeField]
    private GameObject effectPrefab;
    private ShotShell ts;
    private int reward = 10;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            ts = GameObject.Find("ShotShell").GetComponent<ShotShell>();

            ts.AddTripleShotShell(reward);

            Destroy(gameObject);
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
