﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class ItemReciever : MonoBehaviour
{
    public abstract bool Drop(Item item);
}
