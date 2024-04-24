using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemies", menuName = "Enemies/NewEnemy", order = 1)]
public class Enemies : ScriptableObject
{
    [SerializeField] private Material newMaterial;
    [SerializeField] private int speed;
}
