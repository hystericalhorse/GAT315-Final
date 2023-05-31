using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLauncher", menuName = "Game/Launchers")]
public class Launcher : ScriptableObject
{
    [SerializeField] public float Timer;
    [SerializeField] public float Power;
}
