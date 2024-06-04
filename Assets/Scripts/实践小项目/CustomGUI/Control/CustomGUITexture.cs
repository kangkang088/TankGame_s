using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGUITexture : CustomGUIControl {
    public ScaleMode mode = ScaleMode.StretchToFill;
    protected override void StyleOffDraw() {
        GUI.DrawTexture(guiPos.Pos, content.image,mode);
    }

    protected override void StyleOnDraw() {
        GUI.DrawTexture(guiPos.Pos, content.image, mode);
    }
}
