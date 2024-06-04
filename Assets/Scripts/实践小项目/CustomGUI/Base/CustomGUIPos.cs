using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 对齐方式枚举
/// </summary>
public enum E_Alignment_Type {
    Up,
    Down,
    Left,
    Right,
    Center,
    LeftUp,
    LeftDown,
    RightUp,
    RightDown,
}
/// <summary>
/// 该类是用来表示位置，计算位置相关信息的，不需要继承MonoBehaviour
/// </summary>
[System.Serializable]
public class CustomGUIPos {
    //处理位置信息  完成分辨率自适应
    private Rect rPos = new Rect(0, 0, 100, 100);
    //屏幕九宫格对齐方式
    public E_Alignment_Type sceen_Alignment_Type = E_Alignment_Type.Center;
    //控制中心对齐方式
    public E_Alignment_Type control_Center_Alignment_Type = E_Alignment_Type.Center;
    //偏移位置
    public Vector2 pos;
    //宽高
    public float width = 100;
    public float height = 50;
    //用于计算的中心点成员变量
    private Vector2 centerPos;
    //计算中心点偏移的方法
    private void CalcCenterPos() {
        switch (control_Center_Alignment_Type) {
            case E_Alignment_Type.Up:
                centerPos.x = -width / 2;
                centerPos.y = 0;
                break;
            case E_Alignment_Type.Down:
                centerPos.x = -width / 2;
                centerPos.y = -height;
                break;
            case E_Alignment_Type.Left:
                centerPos.x = 0;
                centerPos.y = -height / 2;
                break;
            case E_Alignment_Type.Right:
                centerPos.x = -width;
                centerPos.y = -height / 2;
                break;
            case E_Alignment_Type.Center:
                centerPos.x = -width / 2;
                centerPos.y = -height / 2;
                break;
            case E_Alignment_Type.LeftUp:
                centerPos.x = 0;
                centerPos.y = 0;
                break;
            case E_Alignment_Type.LeftDown:
                centerPos.x = 0;
                centerPos.y = -height;
                break;
            case E_Alignment_Type.RightUp:
                centerPos.x = -width;
                centerPos.y = 0;
                break;
            case E_Alignment_Type.RightDown:
                centerPos.x = -width;
                centerPos.y = -height;
                break;
        }
    }
    //计算最终相对位置坐标的方法
    private void CalcPos() {
        switch (sceen_Alignment_Type) {
            case E_Alignment_Type.Up:
                rPos.x = Screen.width / 2 + centerPos.x + pos.x;
                rPos.y = 0 + centerPos.y + pos.y;
                break;
            case E_Alignment_Type.Down:
                rPos.x = Screen.width / 2 + centerPos.x + pos.x;
                //修改了y轴的方向
                rPos.y = Screen.height + centerPos.y - pos.y;
                break;
            case E_Alignment_Type.Left:
                rPos.x = 0 + centerPos.x + pos.x;
                rPos.y = Screen.height / 2 + centerPos.y + pos.y;
                break;
            case E_Alignment_Type.Right:
                rPos.x = Screen.width + centerPos.x - pos.x;
                rPos.y = Screen.height / 2 + centerPos.y + pos.y;
                break;
            case E_Alignment_Type.Center:
                rPos.x = Screen.width / 2 + centerPos.x + pos.x;
                rPos.y = Screen.height / 2 + centerPos.y + pos.y;
                break;
            case E_Alignment_Type.LeftUp:
                rPos.x = centerPos.x + pos.x;
                rPos.y = centerPos.y + pos.y;
                break;
            case E_Alignment_Type.LeftDown:
                rPos.x = centerPos.x + pos.x;
                rPos.y = Screen.height + centerPos.y - pos.y;
                break;
            case E_Alignment_Type.RightUp:
                rPos.x = Screen.width + centerPos.x - pos.x;
                rPos.y = centerPos.y + pos.y;
                break;
            case E_Alignment_Type.RightDown:
                rPos.x = Screen.width + centerPos.x - pos.x;
                rPos.y = Screen.height + centerPos.y - pos.y;
                break;
        }
    }
    /// <summary>
    /// 最终的位置坐标
    /// </summary>
    public Rect Pos {
        get {
            //计算中心点偏移
            CalcCenterPos();
            //最终控件坐标（分辨率自适应）
            CalcPos();
            rPos.width = width;
            rPos.height = height;
            return rPos;
        }
    }
}
