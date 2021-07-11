using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace JK.Utils
{
    public class DisableOnStart : MonoBehaviour
    {
        #region Inspector

        

        #endregion

        private void Start()
        {
            gameObject.SetActive(false);
        }
    }
}