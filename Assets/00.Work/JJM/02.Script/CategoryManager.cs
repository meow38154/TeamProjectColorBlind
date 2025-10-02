using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ItemState
{
    public string ItemID;
    public int Count;
}

public class CategoryManager : Singleton<CategoryManager>
{
    [SerializeField] private ItemState[] _states;
}
