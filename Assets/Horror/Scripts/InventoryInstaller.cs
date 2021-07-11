using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Horror
{
    public class InventoryInstaller : MonoInstaller
    {
        #region Inspector fields

        

        #endregion

        public override void InstallBindings()
        {
            Container.Bind<Inventory>().ToSelf().AsSingle();
        }
    }
}