using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombSetting : MonoBehaviour
{
    [SerializeField]
    private GameObject BombPrefab;

    private float timer;
    private float timeBetweenBomb = 5;

    public int bombCount;

    [SerializeField]
    private Text bombLabel;

    public int bombMaxCount = 5;

    // Start is called before the first frame update
    void Start()
    {
        bombLabel.text = "爆弾" + bombCount;

        bombCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.B) && timer > timeBetweenBomb && bombCount > 0)
        {
            timer = 0.0f;

            bombCount -= 1;

            GameObject shell = Instantiate(BombPrefab, transform.position, Quaternion.identity);

        }
    }

    public void AddBomb(int amount)
    {
        bombCount += amount;

        if(bombCount > bombMaxCount)
        {
            bombCount = bombMaxCount;
        }

        bombLabel.text = "爆弾" + bombCount;
    }
}
