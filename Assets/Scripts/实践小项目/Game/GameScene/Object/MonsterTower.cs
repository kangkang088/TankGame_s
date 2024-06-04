using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTower : TankBaseObj {
    public float fireOffsetTime = 1;
    public Transform[] shootPos;
    public GameObject bulletObj;
    private float nowTime = 0;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        nowTime += Time.deltaTime;
        if (nowTime > fireOffsetTime) {
            Fire();
            nowTime = 0;
        }
    }
    public override void Fire() {
        for (int i = 0; i < shootPos.Length; i++) {
            GameObject obj = Instantiate(bulletObj, shootPos[i].position, shootPos[i].rotation);
            BulletObj bullet = obj.GetComponent<BulletObj>();
            bullet.SetFather(this);
        }
    }
    public override void Wound(TankBaseObj other) {
        
    }
}
