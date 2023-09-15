using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] wallPrefab;
    public GameObject[] itemPrefab;
    public GameObject dropPrefab;
    public float interval = 1.5f;
    public float range = 3;
    float term;

    Player player;

    public float item_interval = 10f;
    float item_term;

    // Start is called before the first frame update
    void Start()
    {
        term = interval;
        item_term = item_interval;
        player = GameObject.Find(name: "Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.spawn_speedup)
        {
            interval -= 0.2f;
            player.spawn_speedup = false;
        }

        term += Time.deltaTime;
        //item_term += Time.deltaTime;

        if (term >= interval)
        {
            int Randwall = Random.Range(0, wallPrefab.Length);
            Vector3 pos = transform.position;
            pos.y += Random.Range(-range, range);
            Instantiate(wallPrefab[Randwall], pos, transform.rotation);

           // if (Random.Range(0, 2) == 0)
           //     Instantiate(dropPrefab);
            term -= interval;

            //Random Interval
            //interval = Random.Range(0.5f, 1f);
        }


    }
}
