using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackMusic : MonoBehaviour {
    private static BackMusic instance;
    public static BackMusic Instance => instance;

    private AudioSource audioSource;
    private BackMusic() {
        
    }
    private void Awake() {
        instance = this;
        audioSource = this.GetComponent<AudioSource>();
        ChangeValue(GameDataMgr.Instance.musicData.bckValue);
        ChangeOpne(GameDataMgr.Instance.musicData.isOpenBack);
    }
    public void ChangeValue(float value) {
        audioSource.volume = value;
    }
    public void ChangeOpne(bool isOpen) {
        audioSource.mute = !isOpen;
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}
