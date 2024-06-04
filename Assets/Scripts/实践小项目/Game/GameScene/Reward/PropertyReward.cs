using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_Type_Property {
    ATK,
    DEF,
    HP,
    MAXHP
}
public class PropertyReward : MonoBehaviour {
    public E_Type_Property type;
    public int changeValue = 2;
    public GameObject getEff;
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            PlayerObj player = other.GetComponent<PlayerObj>();
            switch (type) {
                case E_Type_Property.ATK:
                    player.atk += changeValue;
                    break;
                case E_Type_Property.DEF:
                    player.def += changeValue;
                    break;
                case E_Type_Property.HP:
                    player.hp += changeValue;
                    if (player.hp > player.maxHp)
                        player.hp = player.maxHp;
                    GamePanel.Instance.UpdateHP(player.maxHp, player.hp);
                    break;
                case E_Type_Property.MAXHP:
                    player.maxHp += changeValue;
                    GamePanel.Instance.UpdateHP(player.maxHp, player.hp);
                    break;
            }
            GameObject eff = Instantiate(getEff, this.transform.position, this.transform.rotation);
            AudioSource audioSource = eff.GetComponent<AudioSource>();
            audioSource.volume = GameDataMgr.Instance.musicData.soundValue;
            audioSource.mute = !GameDataMgr.Instance.musicData.isOpenSound;
            Destroy(this.gameObject);
        }
    }
}
