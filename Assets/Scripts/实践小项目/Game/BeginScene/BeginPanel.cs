using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginPanel : BasePanel<BeginPanel> {
    public CustomGUIButton btnBegin;
    public CustomGUIButton btnSettings;
    public CustomGUIButton btnQuit;
    public CustomGUIButton btnRank;
    // Start is called before the first frame update
    void Start() {
        Cursor.lockState = CursorLockMode.Confined;
        btnBegin.clickEvent += () => {
            //切换场景
            SceneManager.LoadScene("GameScene");
        };
        btnSettings.clickEvent += () => {
            //打开设置面板
            SettingPanel.Instance.ShowMe();
            HideMe();
        };
        btnQuit.clickEvent += () => {
            //退出游戏
            Application.Quit();
        };
        btnRank.clickEvent += () => {
            //打开排行榜
            RankPanel.Instance.ShowMe();
            HideMe();
        };
    }

    // Update is called once per frame
    void Update() {

    }
}
