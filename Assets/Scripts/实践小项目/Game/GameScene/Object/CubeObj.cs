using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeObj : MonoBehaviour {
    public GameObject[] rewardObjs;
    public GameObject deadEff;
    private void OnTriggerEnter(Collider other) {
        //随机产生奖励
        int rangeInt = Random.Range(0, 100);
        //50 percent of create  a reward.
        if (rangeInt < 50) {
            rangeInt = Random.Range(0, rewardObjs.Length);
            Instantiate(rewardObjs[rangeInt], this.transform.position, this.transform.rotation);
        }
        GameObject effObj = Instantiate(deadEff, transform.position, transform.rotation);
        AudioSource audioSource = effObj.GetComponent<AudioSource>();
        audioSource.volume = GameDataMgr.Instance.musicData.soundValue;
        audioSource.mute = !GameDataMgr.Instance.musicData.isOpenSound;
        //奖励Cube是否能被Monster也摧毁
        //if (other.GetComponent<BulletObj>().fatherObj.CompareTag("Player"))
            Destroy(this.gameObject);
    }
}
