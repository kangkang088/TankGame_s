using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitPanel : BasePanel<QuitPanel> {
    public CustomGUIButton btnYes;
    public CustomGUIButton btnCancel;
    public CustomGUIButton btnClose;

    // Start is called before the first frame update
    void Start() {
        btnYes.clickEvent += () => {
            //back mainscene
            SceneManager.LoadScene("BeginScene");
        };
        btnCancel.clickEvent += () => {
            //go on game
            HideMe();
        };
        btnClose.clickEvent += () => {
            //close panel
            HideMe();
        };
        HideMe();
    }
    public override void HideMe() {
        base.HideMe();
        Time.timeScale = 1;
    }
    // Update is called once per frame
    void Update() {

    }
}
