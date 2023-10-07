using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
    public AudioClip voice1;
    public AudioClip voice2;

    public AudioClip voice3;
    private Animator animator;
    private AudioSource univoice;

    private int motionIdol = Animator.StringToHash("Base Layer.Idol");

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        univoice = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Touch", false);
        animator.SetBool("TouchHead", false);

        if (animator.GetCurrentAnimatorStateInfo(0).fullPathHash == motionIdol)
            animator.SetBool("Motion_Idle", true);
        else
            animator.SetBool("Motion_Idle", false);

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                GameObject hitObj = hit.collider.gameObject;
                if (hitObj.tag == "Head")
                {
                    animator.SetBool("TouchHead", true);
                    animator.SetBool("Face_Happy", true);
                    animator.SetBool("Face_Angry", false);
                    univoice.clip = voice1;
                    univoice.Play();
                    MsgDisp.ShowMessage("¾È³ç!\n¿À´Ãµµ ÈûÂ÷°Ô ½ÃÀÛÇØº¸ÀÚ!");
                }
                else if (hitObj.tag == "Body")
                {
                    animator.SetBool("Touch", true);
                    univoice.clip = voice2;
                    univoice.Play();
                    MsgDisp.ShowMessage("²¦!");
                }
                else if (hitObj.tag == "Arm")
                {
                    System.DateTime now = System.DateTime.Now;
                    animator.SetBool("TouchHead", true);
                    animator.SetBool("Face_Happy", true);
                    animator.SetBool("Face_Angry", false);
                    //univoice.clip = voice3;
                    //univoice.Play();
                    MsgDisp.ShowMessage(now.Year + "³â " + now.Month + "¿ù " + now.Day + "ÀÏ " +
                        now.Hour + "½Ã " + now.Minute + "ºÐ ");

                }

            }
        }
    }
}
