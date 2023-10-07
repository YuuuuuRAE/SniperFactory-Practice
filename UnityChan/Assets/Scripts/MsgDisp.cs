using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MsgDisp : MonoBehaviour
{
    public static string msg;
    public static bool flagDiaplay = false;
    public GUIStyle guiDisplay;

    private Rect rtDisplay = new Rect();



    private void OnGUI()
    {
        const float guiScreen = 1280; // 1280 x 720 �ػ� ����
        const float guiWidth = 800; //800x200 �ȼ��� �޼��� â
        const float guiHeight = 200;
        const float guiLeft = (guiScreen - guiWidth) / 2; // ���
        const float guiTop = 720 - guiHeight - 20; // �ϴ�

        float gui_scale = Screen.width / guiScreen;

        if (flagDiaplay){
            //�۲� ��Ÿ��
            GUIStyle msgFont = new GUIStyle
            {
                fontSize = (int)(30 * gui_scale)
            };

            //�޼���â ��ġ ���
            rtDisplay.x = guiLeft * gui_scale;
            rtDisplay.y = guiTop * gui_scale;
            rtDisplay.width = guiWidth * gui_scale;
            rtDisplay.height = guiHeight * gui_scale;

            //�޼���â ���
            GUI.Box(rtDisplay, "â", guiDisplay);

            //�޼��� �׸��� ���
            msgFont.normal.textColor = Color.black;
            rtDisplay.x = (guiLeft + 22) * gui_scale;
            rtDisplay.y = (guiTop + 22) * gui_scale;
            GUI.Label(rtDisplay, msg, msgFont);
        }
    }

    //�ܺο��� �޼��� �ޱ�
    public static void ShowMessage(string msg)
    {
        MsgDisp.msg = msg;
        flagDiaplay = true;
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
