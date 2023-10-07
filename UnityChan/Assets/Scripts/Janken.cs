using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Janken : MonoBehaviour
{
    bool flagJanken = false;
    int modeaJanken = 0;

    public AudioClip voiceStart;
    public AudioClip voicePon;
    public AudioClip voiceGoo;
    public AudioClip voiceChoki;
    public AudioClip voicePar;
    public AudioClip voiceWin;
    public AudioClip voiceLoose;
    public AudioClip voiceDraw;

    const int JANKEN = -1;
    const int GOO = 0;
    const int CHOKI = 1;
    const int PAR = 2;
    const int DRAW = 3;
    const int WIN = 4;
    const int LOOSE = 5;

    private Animator animator;
    private AudioSource univoice;

    int myHand;
    int unityHand;
    int flagResult;
    int[,] tableresult = new int[3,3];
    float waitDelay;

    public GUIStyle guiBtnGame;
    public GUIStyle guiBtnGoo;
    public GUIStyle guiBtnChoki;
    public GUIStyle guiBtnPar;

    private Rect rtBtnGame = new Rect();
    private Rect rtBtnGoo = new Rect();
    private Rect rtBtnChoki = new Rect();
    private Rect rtBtnPar = new Rect();


    private void OnGUI()
    {
        const float guiScreen = 1280;
        const float guiPadding = 10;
        const float guiButton = 200;
        const float guiTop = 720 - guiButton - guiPadding;

        float gui_scale = Screen.width / guiScreen;
        float scaledPadding = guiPadding * gui_scale;
        float scaledButton = guiButton * gui_scale;
        float scaledTop = guiTop * gui_scale;

        rtBtnGame.x = scaledPadding;
        rtBtnGame.y = scaledTop;
        rtBtnGame.width = scaledButton;
        rtBtnGame.height = scaledButton;

        float left = (guiScreen - guiPadding * 2 - guiButton * 3) / 2 * gui_scale;
        rtBtnGoo.x = left;
        rtBtnGoo.y = scaledTop;
        rtBtnGoo.width = scaledButton;
        rtBtnGoo.height = scaledButton;

        left += scaledButton + scaledPadding;
        rtBtnChoki.x = left;
        rtBtnChoki.y = scaledTop;
        rtBtnChoki.width = scaledButton;
        rtBtnChoki.height = scaledButton;

        left += scaledButton + scaledPadding;
        rtBtnPar.x = left;
        rtBtnPar.y = scaledTop;
        rtBtnPar.width = scaledButton;
        rtBtnPar.height = scaledButton;



        if (!flagJanken)
        {
            flagJanken = (GUI.Button(rtBtnGame, "¹¬Âîºü", guiBtnGame));
        }

        if (modeaJanken == 1)
        {
            if (GUI.Button(rtBtnGoo, "¹¬", guiBtnGoo))
            {
                myHand = GOO;
                modeaJanken++;
            }
            if (GUI.Button(rtBtnChoki, "Âî", guiBtnChoki)) 
            {
                myHand = CHOKI;
                modeaJanken++;
            }
            if (GUI.Button(rtBtnPar,"ºü",guiBtnPar))
            {
                myHand = PAR;
                modeaJanken++;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        univoice = GetComponent<AudioSource>();
        tableresult[GOO, GOO] = DRAW;
        tableresult[GOO, CHOKI] = WIN;
        tableresult[GOO, PAR] = LOOSE;
        tableresult[CHOKI, GOO] = LOOSE;
        tableresult[CHOKI, CHOKI] = DRAW;
        tableresult[CHOKI, PAR] = WIN;
        tableresult[PAR, GOO] = WIN;
        tableresult[PAR, CHOKI] = LOOSE;
        tableresult[PAR, PAR] = DRAW;

    }

    // Update is called once per frame
    void Update()
    {
        if (flagJanken)
        {
            switch (modeaJanken) { 
                case 0:
                    UnityChanAction(JANKEN);
                    modeaJanken++;
                    break;

                case 1:
                    animator.SetBool("Janken", false);
                    animator.SetBool("Aiko", false);
                    animator.SetBool("Goo", false);
                    animator.SetBool("Choki", false);
                    animator.SetBool("Par", false);
                    animator.SetBool("Win", false);
                    animator.SetBool("Loose", false);
                    break;

                case 2:
                    flagResult = JANKEN;
                    unityHand = Random.Range(GOO, PAR + 1);
                    UnityChanAction(unityHand);

                    flagResult = tableresult[unityHand, myHand];
                    modeaJanken++;
                    break;

                case 3:
                    waitDelay += Time.deltaTime;
                    if (waitDelay > 1.5f)
                    {
                        UnityChanAction(flagResult);

                        waitDelay = 0;
                        modeaJanken++;
                    }
                    break;

                default:
                    flagJanken = false;
                    modeaJanken = 0;
                    break;
            }
        }
    }

    void UnityChanAction(int act)
    {
        switch(act)
        {
            case JANKEN:
                animator.SetBool("Janken", true);
                univoice.clip = voiceStart;
                break;

            case GOO:
                animator.SetBool("Goo", true);
                univoice.clip = voiceGoo;
                break;

            case CHOKI:
                animator.SetBool("Choki", true);
                univoice.clip = voiceChoki;
                break;

            case PAR:
                animator.SetBool("Par", true);
                univoice.clip = voicePar;
                break;

            case DRAW:
                animator.SetBool("Aiko", true);
                univoice.clip = voiceDraw;
                break;

            case WIN:
                animator.SetBool("Win", true);
                univoice.clip = voiceWin;
                break;

            case LOOSE:
                animator.SetBool("Loose", true);
                univoice.clip = voiceLoose;
                break;
        }

        univoice.Play();
    }


}
