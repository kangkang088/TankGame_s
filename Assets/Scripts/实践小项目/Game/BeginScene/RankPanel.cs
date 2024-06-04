using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankPanel : BasePanel<RankPanel> {
    public CustomGUIButton btnClose;
    //private List<CustomGUILabel> labelPM = new List<CustomGUILabel>();
    private List<CustomGUILabel> labelNAME = new List<CustomGUILabel>();
    private List<CustomGUILabel> labelSCORE = new List<CustomGUILabel>();
    private List<CustomGUILabel> labelTIME = new List<CustomGUILabel>();
    // Start is called before the first frame update
    void Start() {
        for (int i = 1; i <= 10; i++) {
            //labelPM.Add(this.transform.Find("PM/LabelPM" + i).GetComponent<CustomGUILabel>());
            labelNAME.Add(this.transform.Find("NAME/LabelNAM" + i).GetComponent<CustomGUILabel>());
            labelSCORE.Add(this.transform.Find("SCORE/LabelSCORE" + i).GetComponent<CustomGUILabel>());
            labelTIME.Add(this.transform.Find("TIME/LabelTIME" + i).GetComponent<CustomGUILabel>());
        }
        btnClose.clickEvent += () => {
            HideMe();
            BeginPanel.Instance.ShowMe();
        };
        //GameDataMgr.Instance.AddRankInfo("测试数据", 100, 8432);
        HideMe();
    }
    public void UpdatePanelInfo() {
        List<RankInfo> list = GameDataMgr.Instance.rankData.list;
        for (int i = 0; i < list.Count; i++) {
            labelNAME[i].content.text = list[i].name;
            labelSCORE[i].content.text = list[i].score.ToString();
            //时间 存储单位是s 转换成时分秒
            int time = (int)list[i].time;
            labelTIME[i].content.text = "";
            if (time / 3600 > 0) {
                labelTIME[i].content.text += time / 3600 + "时";
            }
            if (time % 3600 / 60 > 0 || labelTIME[i].content.text != "") {
                labelTIME[i].content.text += time % 3600 / 60 + "分";
            }
            labelTIME[i].content.text += time % 60 + "秒";
        }
    }

    public override void ShowMe() {
        base.ShowMe();
        UpdatePanelInfo();
    }


    // Update is called once per frame
    void Update() {

    }
}
