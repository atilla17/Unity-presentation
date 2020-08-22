using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyFall : MonoBehaviour {

    public GameObject moneyType1;
    public Vector3 pos;

    bool drop = false;

    int objectCount = 0;
    int MaxObj = 100;
	// Use this for initialization
	void Start () {
        pos = transform.position;
	}

    void OnEnable()
    {
        why0Script.OnMoneyStart += SetDrop;
        why0Script.OnMoneyStop += StopDrop;
    }
    void OnDisable()
    {
        why0Script.OnMoneyStart -= SetDrop;
        why0Script.OnMoneyStop -= StopDrop;
    }

    // Update is called once per frame
    void Update () {
		
        if(drop)
        {

            for (int i = 0; i < 350 * Time.deltaTime; i++)
            {
                float randomX = Random.Range(pos.x - 2, pos.x + 2);
                float randomY = Random.Range(pos.y - 5, pos.y + 5);
                float randomZ = Random.Range(pos.z - 3, pos.z + 3);
                Vector3 newPos = new Vector3(randomX, pos.y, randomZ);
                GameObject go = GameObject.Instantiate(moneyType1, newPos, Quaternion.identity);
            }
        }

	}

    void SetDrop()
    {
        drop = true;
    }
    void StopDrop()
    {
        drop = false;
    }

}
