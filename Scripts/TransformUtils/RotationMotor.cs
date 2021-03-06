﻿using UnityEngine;

namespace RichUnity.TransformUtils
{
    public class RotationMotor : MonoBehaviour
    {
        public Vector3 Axis = new Vector3(0.0f, 0.0f, 1.0f);
        public float AnglularSpeed;

        private Transform transform; // cached transform

        private void Awake()
        {
            transform = GetComponent<Transform>();
        }
        
        private void Update()
        {
            transform.Rotate(Axis, AnglularSpeed * Time.deltaTime);
        }
    }
}