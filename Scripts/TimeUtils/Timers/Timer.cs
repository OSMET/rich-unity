﻿using RichUnity.Attributes;
using UnityEngine;

namespace RichUnity.TimeUtils.Timers {
    public class Timer {
#if UNITY_EDITOR
        [ReadOnly]
        [SerializeField]
#endif
        private float time;

        public float Time {
            get {
                return time;
                
            }
            private set {
                time = value;
            }
        }
        
#if UNITY_EDITOR
        [ReadOnly]
        [SerializeField]
#endif
        private bool timerOn;

        public bool TimerOn {
            get {
                return timerOn;
            }
            private set {
                timerOn = value;
            }
        }

        public Timer() {
        }

        public virtual void Start() {
            TimerOn = true;
            Time = 0.0f;
        }
        
        public virtual void End() {
            TimerOn = false;
        }

        public virtual void Resume() {
            TimerOn = true;
        }

        public virtual void Update(float delta) {
            AddTime(delta);
        }

        public virtual void AddTime(float time) {
            if (TimerOn) {
                Time += time;
                if (Time < 0f) {
                    Time = 0f;
                }
            }
        }
    }
}