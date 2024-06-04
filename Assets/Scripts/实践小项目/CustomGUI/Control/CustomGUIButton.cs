using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomGUIButton : CustomGUIControl
{
    //提供给外部用于响应按钮点击的事件
    public event UnityAction clickEvent;
    protected override void StyleOffDraw() {
        if (GUI.Button(guiPos.Pos, content)) {
            clickEvent?.Invoke();
        }
    }

    protected override void StyleOnDraw() {
        if (GUI.Button(guiPos.Pos, content,style)) {
            clickEvent?.Invoke();
        }
    }

}
