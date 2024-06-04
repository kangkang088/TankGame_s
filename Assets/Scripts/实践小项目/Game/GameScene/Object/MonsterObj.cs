using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterObj : TankBaseObj {
    //1.坦克在两点间来回移动
    private Transform targetPos;
    public Transform[] randomPos;
    //2.坦克一直盯着自己的目标
    public Transform lookAtTarget;
    //3.目标到达范围后，间隔一定时间攻击一次
    public float fireDistance = 5.0f;
    public float fireOffsetTime = 1;
    private float nowTime = 0;
    //开火点和子弹预设体
    public Transform[] shootPos;
    public GameObject bulletObj;

    public Texture maxHpBk;
    public Texture HpBk;
    private Rect maxHpRect;
    private Rect HpRect;
    private float showTime;
    // Start is called before the first frame update
    void Start() {
        RandomPos();
    }

    // Update is called once per frame
    void Update() {
        this.transform.LookAt(targetPos);
        this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if (Vector3.Distance(this.transform.position, targetPos.position) < 0.05f) {
            RandomPos();
        }
        #region 看向自己的目标
        if (lookAtTarget != null) {
            tankHead.LookAt(lookAtTarget);
            if (Vector3.Distance(this.transform.position, lookAtTarget.position) <= fireDistance) {
                nowTime += Time.deltaTime;
                if (nowTime >= fireOffsetTime) {
                    Fire();
                    nowTime = 0;
                }
            }
        }
        #endregion
    }
    void RandomPos() {
        if (randomPos.Length == 0)
            return;
        targetPos = randomPos[Random.Range(0, randomPos.Length)];
    }
    public override void Fire() {
        for (int i = 0; i < shootPos.Length; i++) {
            GameObject obj = Instantiate(bulletObj, shootPos[i].position, shootPos[i].rotation);
            BulletObj bullet = obj.GetComponent<BulletObj>();
            bullet.SetFather(this);
        }
    }
    public override void Dead() {
        base.Dead();
        //加分
        GamePanel.Instance.AddScore(10);
    }
    private void OnGUI() {
        if (showTime > 0) {
            showTime -= Time.deltaTime;
            Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
            screenPos.y = Screen.height - screenPos.y;
            maxHpRect.x = screenPos.x - 50;
            maxHpRect.y = screenPos.y - 45;
            maxHpRect.width = 100;
            maxHpRect.height = 15;
            GUI.DrawTexture(maxHpRect, maxHpBk);

            HpRect.x = screenPos.x - 50;
            HpRect.y = screenPos.y - 45;
            HpRect.width = (float)hp / maxHp * 100f;
            HpRect.height = 15;
            GUI.DrawTexture(HpRect, HpBk);
        }
        
    }
    public override void Wound(TankBaseObj other) {
        base.Wound(other);
        //设置血条显示时间
        showTime = 3f;
    }
}
