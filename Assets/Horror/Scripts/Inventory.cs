using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Horror
{
    [Serializable]
    public class Inventory
    {
        public List<string> items = new List<string>();
    }
    
    [Serializable]
    public class UnityEventInventory : UnityEvent<Inventory> { }
}