﻿using System.Collections;
using Assets.Plugins.RichUnity.Math;
using UnityEngine;

namespace Assets.Plugins.RichUnity.Utils {
    public class SmoothMover : MonoBehaviour {
        public Vector3 TargetPosition { get; set; }
        public float SmoothTime;
        private Vector3 velocity = Vector3.zero;
        private bool stopWhenReach;
        public bool Moving { get; private set; }

        public void BeginMoving(bool stopWhenReach = true) {
            this.stopWhenReach = stopWhenReach;
            Moving = true;
        }

        public void StopMoving() {
            Moving = false;
            velocity = Vector3.zero;
        }

        public void Update() {
            if (Moving) {
                if (Vector3Utils.PrecisionEquals(TargetPosition, transform.position, 0.0001f)) {
                    transform.position = TargetPosition;
                    velocity = Vector3.zero;
                    if (stopWhenReach) {
                        Moving = false;
                    }
                } else {
                    Vector3 newPosition = Vector3.SmoothDamp(transform.position, TargetPosition, ref velocity,
                        SmoothTime,
                        Mathf.Infinity, Time.fixedDeltaTime);
                    transform.position = newPosition;
                }
            }
        }


           
    }
}