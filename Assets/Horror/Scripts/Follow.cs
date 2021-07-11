using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Horror
{
    public class Follow : MonoBehaviour
    {
        #region Inspector

        public Transform target;

        #endregion

        private void Update()
        {
            if (target != null)
                transform.position = target.position;
        }
    }
    
    [Serializable]
    public class UnityEventFollow : UnityEvent<Follow> { }
}