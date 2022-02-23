using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy/New Enemy")]
public class Enemy : ScriptableObject
{
    public float Health;
    public float Speed;
    public Sprite Sprite;
}
