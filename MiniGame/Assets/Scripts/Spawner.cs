using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] wallPrefab;
    public GameObject dropPrefab;
    public float interval = 1.5f;
    public float range = 3;
    float term;

    // Start is called before the first frame update
    void Start()
    {
        term = interval;
    }

    // Update is called once per frame
    void Update()
    {
        term += Time.deltaTime;
        if (term >= interval)
        {
            int Randwall = Random.Range(0, 3);
            Vector3 pos = transform.position;
            pos.y += Random.Range(-range, range);
            Instantiate(wallPrefab[Randwall], pos, transform.rotation);

            if (Random.Range(0, 2) == 0)
                Instantiate(dropPrefab);
            term -= interval;

            //Random Interval
            //interval = Random.Range(0.5f, 2);
        }
    }
}
