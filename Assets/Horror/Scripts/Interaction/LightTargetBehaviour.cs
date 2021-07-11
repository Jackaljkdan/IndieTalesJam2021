using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Horror.Interaction
{
    public abstract class LightTargetBehaviour : MonoBehaviour, ILightTarget
    {
        #region Inspector

        #endregion

        public abstract Light Light { get; }

        public abstract bool StartsOff { get; }

        public abstract bool IsOn { get; protected set; }

        public abstract void Toggle();
    }
}