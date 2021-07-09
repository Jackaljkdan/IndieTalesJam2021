using JK.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Horror.Actuators
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Rigidbody))]
    public class RigidBodyMovementActuator : MonoBehaviour, IMovementActuator
    {
        #region Inspector

        [SerializeField]
        private float _speed = 3;

        public float acceleration = 300;

        public Transform _directionReference;

        [SerializeField]
        private UnityEventVector3 _onMovement = new UnityEventVector3();

        private void Reset()
        {
            DirectionReference = transform;

            var body = GetComponent<Rigidbody>();
            body.isKinematic = false;
        }

        #endregion

        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }

        public Vector3 Input { get; set; }

        public Transform DirectionReference
        {
            get => _directionReference;
            set => _directionReference = value;
        }

        public UnityEventVector3 onMovement => _onMovement;

        private void Update()
        {
            if (Input.sqrMagnitude == 0)
                return;

            var body = GetComponent<Rigidbody>();

            Vector3 directionedInput = DirectionReference.TransformDirection(Input);
            directionedInput.y = 0;
            directionedInput = Vector3.ClampMagnitude(directionedInput, 1);

            float multiplier = Mathf.Lerp(acceleration, 0, body.velocity.sqrMagnitude / (Speed * Speed));
            Vector3 accelerationForce = directionedInput * multiplier;

            body.AddForce(accelerationForce, ForceMode.Acceleration);

            onMovement.Invoke(Input);

            Input = Vector3.zero;
        }
    }
    
    [Serializable]
    public class UnityEventRigidBodyMovementActuator : UnityEvent<RigidBodyMovementActuator> { }
}