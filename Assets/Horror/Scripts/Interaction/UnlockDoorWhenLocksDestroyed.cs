using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Horror.Interaction
{
    public class UnlockDoorWhenLocksDestroyed : MonoBehaviour
    {
        #region Inspector



        #endregion

        [Inject]
        private List<LockInteractable> locks = null;

        [Inject]
        private DoorInteractable door = null;

        private void OnDestroy()
        {
            int destroyedCount = 1;

            foreach (var doorLock in locks)
                if (doorLock == null)
                    destroyedCount++;

            if (destroyedCount == locks.Count)
                door.IsLocked = false;
        }

    }
    
    [Serializable]
    public class UnityEventUnlockDoorWhenLocksDestroyed : UnityEvent<UnlockDoorWhenLocksDestroyed> { }
}