using System;
using UnityEngine;

[CreateAssetMenu(fileName = "AlarmStatus", menuName = "Security/AlarmStatus", order = 0)]
public class AlarmStatus : ScriptableObject
{
    public bool alarmTripped = false;
}