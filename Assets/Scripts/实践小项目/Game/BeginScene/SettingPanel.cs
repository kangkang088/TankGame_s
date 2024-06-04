using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingPanel : BasePanel<SettingPanel> {
    public CustomGUISlider musicSlider;
    public CustomGUISlider soundSlider;
    public CustomGUIToggle toggleMusic;
    public CustomGUIToggle toggleSound;
    public CustomGUIButton btnClose;

    // Start is called before the first frame update
    void Start() {
        musicSlider.changeValue += (value) => GameDataMgr.Instance.ChangeBackValue(value);
        soundSlider.changeValue += (value) => GameDataMgr.Instance.ChangeSoundValue(value);

        toggleMusic.changeValue += (value) => GameDataMgr.Instance.OpenOrCloseBackMusic(value);
        toggleSound.changeValue += (value) => GameDataMgr.Instance.OpenOrCloseBackSound(value);

        btnClose.clickEvent += () => {
            HideMe();
            if (SceneManager.GetActiveScene().name == "BeginScene")
                BeginPanel.Instance.ShowMe();
            if (SceneManager.GetActiveScene().name == "GameScene") {
            }

        };
        HideMe();
    }
    public void UpdatePanelInfo() {
        MusicData data = GameDataMgr.Instance.musicData;
        musicSlider.nowValue = data.bckValue;
        soundSlider.nowValue = data.soundValue;
        toggleMusic.isSel = data.isOpenBack;
        toggleSound.isSel = data.isOpenSound;
    }


    // Update is called once per frame
    void Update() {

    }

    public override void ShowMe() {
        base.ShowMe();
        UpdatePanelInfo();
    }
    public override void HideMe() {
        base.HideMe();
        Time.timeScale = 1;
    }

}
