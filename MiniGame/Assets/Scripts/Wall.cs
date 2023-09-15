using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wall : MonoBehaviour
{

    public float speed = -5;
    Player player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find(name: "Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.speedup)
        {
            Debug.Log("게임 속도가 증가합니다.");
            speed += -0.5f;
            player.speedup = false;
        }
        transform.Translate(speed * Time.deltaTime, 0, 0);
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
            player.addScore(1);
        }

    }


}
