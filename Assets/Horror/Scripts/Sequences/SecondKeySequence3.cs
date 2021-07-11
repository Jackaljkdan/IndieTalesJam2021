using Horror.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Horror.Sequences
{
    public class SecondKeySequence3 : MonoBehaviour
    {
        #region Inspector

        public LightSwitchInteractable lightSwitch;

        public List<GameObject> libraryObstacles;

        #endregion

        [Inject(Id = "lucy")]
        private Transform lucy = null;

        [Inject]
        private FlickeringLight flickering = null;

        private void Start()
        {
            lightSwitch.onInteraction.AddListener(OnLightInteracted);
        }

        private void OnLightInteracted()
        {
            lightSwitch.onInteraction.RemoveListener(OnLightInteracted);

            flickering.StopFlicker();

            var light = flickering.GetComponent<Light>();
            light.enabled = false;
            light.intensity = 0;

            Destroy(lucy.gameObject);

            foreach (var obstacle in libraryObstacles)
                Destroy(obstacle);

            Destroy(gameObject);
        }
    }
    
    [Serializable]
    public class UnityEventSecondKeySequence3 : UnityEvent<SecondKeySequence3> { }
}