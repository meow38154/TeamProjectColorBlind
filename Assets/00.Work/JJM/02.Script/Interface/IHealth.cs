using UnityEngine;
using System;
using UnityEngine.Events;

public interface IHealth
{
    public int MaxHealth { get; }
    public int CurrentHealth { get; }


    public void GetDamage(int damage); //대미지를 입히는 메서드

    public void GetHeal(int heal); //체력 회복을 시키는 메서드

    public void Die(); //죽었을 때 실행될 메서드
}
