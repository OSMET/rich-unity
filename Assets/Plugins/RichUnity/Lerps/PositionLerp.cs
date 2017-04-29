﻿using UnityEngine;

namespace Assets.Plugins.RichUnity.Lerps {
    public class PositionLerp : Lerp<Vector3> {
        public override void ChangeValue(float percentage) {
            transform.position = Vector3.Lerp(BeginValue, EndValue, percentage);
        }
    }
}
