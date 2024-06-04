using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObj : TankBaseObj {
    public WeaponObj nowWeapon;
    public Transform weaponPos;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        //ws ad 鼠标控制炮台旋转
        this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical"));
        this.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
        tankHead.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * Input.GetAxis("Mouse X"));
        if (Input.GetMouseButtonDown(0)) {
            Fire();
        }

    }
    public override void Dead() {
        //这里不执行父类的死亡，因为摄像机在玩家坦克对象里面，执行父类死亡，玩家对象移除，进而会间接移除摄像机
        //base.Dead();
        //显示失败面板
        Time.timeScale = 0;
        LosePanel.Instance.ShowMe();
    }
    public override void Wound(TankBaseObj other) {
        base.Wound(other);
        //更新血条
        GamePanel.Instance.UpdateHP(maxHp, hp);
    }
    public override void Fire() {
        if (nowWeapon != null)
            nowWeapon.Fire();
    }
    public void ChangeWeapon(GameObject weapon) {
        if (nowWeapon != null) {
            Destroy(nowWeapon.gameObject);
            nowWeapon = null;
        }
        GameObject weaponObj = Instantiate(weapon, weaponPos,false);
        nowWeapon = weaponObj.GetComponent<WeaponObj>();
        nowWeapon.SetFather(this);
    }
}
