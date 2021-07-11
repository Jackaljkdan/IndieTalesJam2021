using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Horror
{
    public class PlaceAtPlayerStart : MonoBehaviour
    {
        #region Inspector

        public bool inEditor = true;

        #endregion

        [Inject(Id = "player.start")]
        private Transform playerStart = null;

        private void Start()
        {
            if (!Application.isEditor || inEditor)
                transform.position = playerStart.position;
        }
    }
}