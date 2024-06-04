using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LosePanel : BasePanel<LosePanel>
{
    public CustomGUIButton btnCancel;
    public CustomGUIButton btnGoOn;
    // Start is called before the first frame update
    void Start()
    {
        btnCancel.clickEvent += () => {
            Time.timeScale = 1;
            SceneManager.LoadScene("BeginScene");
        };
        btnGoOn.clickEvent += () => {
            Time.timeScale = 1;
            SceneManager.LoadScene("GameScene");
        };
        HideMe();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
