using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TankBaseObj : MonoBehaviour {
    public int atk;
    public int def;
    public int maxHp;
    public int hp;
    public float moveSpeed = 10;
    public float rotateSpeed = 100;
    public float headRotateSpeed = 100;
    public Transform tankHead;

    public GameObject deadEff;

    public abstract void Fire();
    public virtual void Wound(TankBaseObj other) {
        int damage = other.atk - def;
        if (damage <= 0)
            return;
        hp -= damage;
        if (hp <= 0) {
            //dead
            hp = 0;
            Dead();
        }
    }
    public virtual void Dead() {
        Destroy(this.gameObject);
        //动态创建死亡特效
        if (deadEff != null) {

            GameObject effObj = Instantiate(deadEff, this.transform.position, this.transform.rotation);
            AudioSource audioSource = effObj.GetComponent<AudioSource>();
            audioSource.volume = GameDataMgr.Instance.musicData.soundValue;
            audioSource.mute = !GameDataMgr.Instance.musicData.isOpenSound;
        }
    }
}
