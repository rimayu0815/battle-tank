using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseEnemy : MonoBehaviour
{

    [SerializeField]
    private GameObject target;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }         

    // Update is called once per frame
    void Update()
    {
        if (target != null)//ターゲットが空ではなかったら
        {
            agent.destination = target.transform.position;//目標の位置をエージェントの目的地として設定し取得する

        }
    }
}
