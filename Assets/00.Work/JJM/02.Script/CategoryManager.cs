using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Stats
{
    public string skillName;
    public bool skillRemissionStatus;
    public int skillLevel;
}

public class CategoryManager : Singleton<CategoryManager>
{
    [SerializeField] private Stats[] _states;
}
