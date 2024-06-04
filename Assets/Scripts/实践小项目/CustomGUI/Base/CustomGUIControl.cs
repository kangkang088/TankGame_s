using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_Style_OnOff {
    On,
    Off,
}
public abstract class CustomGUIControl : MonoBehaviour {
    //位置信息
    public CustomGUIPos guiPos;
    //显示内容信息
    public GUIContent content;
    //自定义样式信息
    public GUIStyle style;
    //自定义样式的开关
    public E_Style_OnOff style_OnOrOff = E_Style_OnOff.Off;
    //提供给外部编辑模式下绘制的方法
    public void DrawGUI() {
        switch (style_OnOrOff) {
            case E_Style_OnOff.On:
                StyleOnDraw();
                break;
            case E_Style_OnOff.Off:
                StyleOffDraw();
                break;
        }
    }
    protected abstract void StyleOnDraw();
    protected abstract void StyleOffDraw();
}
