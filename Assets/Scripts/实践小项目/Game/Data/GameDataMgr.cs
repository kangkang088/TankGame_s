using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataMgr {
    private static GameDataMgr instance = new GameDataMgr();
    public static GameDataMgr Instance => instance;
    public MusicData musicData;
    public RankList rankData;
    private GameDataMgr() {
        musicData = PlayerPrefsDataMgr.Instance.LoadData(typeof(MusicData), "Music") as MusicData;
        if (!musicData.notFirst) {
            musicData.notFirst = true;
            musicData.isOpenBack = true;
            musicData.isOpenSound = true;
            musicData.bckValue = 1;
            musicData.soundValue = 1;
            PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
        }
        rankData = PlayerPrefsDataMgr.Instance.LoadData(typeof(RankList), "Rank") as RankList;
    }
    public void AddRankInfo(string name, int score, float time) {
        rankData.list.Add(new RankInfo(name, score, time));
        //排序
        rankData.list.Sort((a, b) => a.time < b.time ? -1 : 1);
        //移除第十条以外的数据
        for (int i = rankData.list.Count - 1; i >= 10; i--) {
            rankData.list.RemoveAt(i);
        }
        PlayerPrefsDataMgr.Instance.SaveData(rankData, "Rank");
    }
    public void OpenOrCloseBackMusic(bool isOpen) {
        musicData.isOpenBack = isOpen;

        BackMusic.Instance.ChangeOpne(isOpen);

        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
    }
    public void OpenOrCloseBackSound(bool isOpen) {
        musicData.isOpenSound = isOpen;
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
    }
    public void ChangeBackValue(float value) {
        musicData.bckValue = value;

        BackMusic.Instance.ChangeValue(value);

        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
    }
    public void ChangeSoundValue(float value) {
        musicData.soundValue = value;
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
    }
}
