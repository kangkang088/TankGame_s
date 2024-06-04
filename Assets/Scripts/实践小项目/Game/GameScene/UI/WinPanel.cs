using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel : BasePanel<WinPanel> {
    public CustomGUIButton btnSure;
    public CustomGUInput inputInfo;
    private void Start() {
        btnSure.clickEvent += () => {
            Time.timeScale = 1;
            GameDataMgr.Instance.AddRankInfo(inputInfo.content.text, GamePanel.Instance.nowScore, GamePanel.Instance.nowTime);
            SceneManager.LoadScene("BeginScene");
        };
        HideMe();
    }
}
