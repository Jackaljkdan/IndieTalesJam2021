using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Horror.Interaction
{
    [RequireComponent(typeof(FlickeringLight))]
    public class LightSwitchFlicker : MonoBehaviour
    {
        #region Inspector

        public LightSwitchInteractable lightSwitch;

        private void Reset()
        {
            GetComponent<FlickeringLight>().flickerOnStart = false;
        }

        #endregion

        private void Start()
        {
            var flickering = GetComponent<FlickeringLight>();
            flickering.enabled = !lightSwitch.lightTarget.StartsOff;

            if (flickering.enabled)
                flickering.StartFlicker();

            lightSwitch.onInteraction.AddListener(OnInteraction);
        }

        private void OnInteraction()
        {
            var flickering = GetComponent<FlickeringLight>();
            flickering.enabled = !flickering.enabled;

            if (flickering.enabled)
                flickering.StartFlicker();
            else
                flickering.StopFlicker();
        }
    }
}