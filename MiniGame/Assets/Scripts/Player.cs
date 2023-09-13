using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float jumppower = 5f;
    TextMesh scoreOutput;
    int score = 0;

    //Try 2
    public float lowWarn = -4;
    public float jumpBoost = -2.5f;

    //Try 3
    public float step = 0.5f;

    //Try 4
    public float scale = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        scoreOutput = GameObject.Find(name: "Score").GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {

        //TRY
        //transform.position += new Vector3(step * Time.deltaTime, 0, 0);
        //transform.localScale += new Vector3(0, scale * Time.deltaTime, 0);

        if (Input.GetButtonDown("Jump"))
        {
            if (transform.position.y < lowWarn)
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0, jumppower * jumpBoost, 0);
            }
            else
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0, jumppower, 0);
            }

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void addScore (int s)
    {
        score += s;
        scoreOutput.text = "Á¡¼ö : " + score;
    }
}
