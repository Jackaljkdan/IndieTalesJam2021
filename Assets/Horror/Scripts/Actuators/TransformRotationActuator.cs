using JK.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Horror.Actuators
{
    [DisallowMultipleComponent]
    public class TransformRotationActuator : MonoBehaviour, IRotationActuator
    {
        #region Inspector

        [SerializeField]
        private float _speed = 3;

        #endregion

        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }

        public Vector2 Input { get; set; }

        private void Update()
        {
            if (Input.sqrMagnitude == 0)
                return;

            float leftRightRotation = Input.x;
            float upDownRotation = Input.y;

            transform.RotateAround(transform.position, Vector3.up, leftRightRotation * Speed * Time.deltaTime);

            Vector3 euler = transform.localEulerAngles;
            euler.x += -upDownRotation * Speed * Time.deltaTime;

            if (euler.x > 180)
                euler.x = Mathf.Max(360 - 89, euler.x);
            else
                euler.x = Mathf.Min(89, euler.x);

            transform.localEulerAngles = euler;

            Input = Vector3.zero;
        }
    }
    
    [Serializable]
    public class UnityEventTransformRotationActuator : UnityEvent<TransformRotationActuator> { }
}