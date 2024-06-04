using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel : BasePanel<GamePanel> {
    public CustomGUILabel labelScore;
    public CustomGUILabel labelTime;
    public CustomGUIButton btnQuit;
    public CustomGUIButton btnSettings;
    public CustomGUITexture textureHp;
    [HideInInspector]
    public int nowScore = 0;

    public float hpWidth = 350;
    [HideInInspector]
    public float nowTime = 0;
    private int time;
    // Start is called before the first frame update
    void Start() {
        btnSettings.clickEvent += () => {
            SettingPanel.Instance.ShowMe();
            Time.timeScale = 0;
        };
        btnQuit.clickEvent += () => {
            QuitPanel.Instance.ShowMe();
            Time.timeScale = 0;
        };
    }
    public void AddScore(int score) {
        nowScore += score;
        labelScore.content.text = nowScore.ToString();
    }
    public void UpdateHP(int maxHp, int Hp) {
        textureHp.guiPos.width = (float)Hp / maxHp * hpWidth;
    }
    // Update is called once per frame
    void Update() {
        nowTime += Time.deltaTime;
        //时间 存储单位是s 转换成时分秒
        time = (int)nowTime;
        labelTime.content.text = "";
        if (time / 3600 > 0) {
            labelTime.content.text += time / 3600 + "时";
        }
        if (time % 3600 / 60 > 0 || labelTime.content.text != "") {
            labelTime.content.text += time % 3600 / 60 + "分";
        }
        labelTime.content.text += time % 60 + "秒";
    }
}
