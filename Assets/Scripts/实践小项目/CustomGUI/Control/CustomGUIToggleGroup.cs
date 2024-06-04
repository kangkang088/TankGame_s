using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGUIToggleGroup : MonoBehaviour {
    public CustomGUIToggle[] toggles;
    private CustomGUIToggle frontToggle;
    private void Start() {
        if (toggles.Length == 0)
            return;
        for (int i = 0; i < toggles.Length; i++) {
            CustomGUIToggle toggle = toggles[i];
            toggle.changeValue += (value) => {
                //value是true时，需要把其他的变为false
                if (value) {
                    for (int j = 0; j < toggles.Length; j++) {
                        if (toggles[j] != toggle) {
                            toggles[j].isSel = false;
                        }
                    }
                    frontToggle = toggle;
                } else if (toggle == frontToggle) {
                    //确定单选框必须有一个选中
                    toggle.isSel = true;
                }
            };
        }
    }
}
