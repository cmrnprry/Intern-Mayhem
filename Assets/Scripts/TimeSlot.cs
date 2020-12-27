using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Really just a super class for the slot system that makes up a level.
public class TimeSlot : MonoBehaviour
{
    /// <summary>
    /// How much time this slot takes up (cutscene time, commercial break time, time before score evaluation, etc).
    /// </summary>
    public float TimeToComplete;
}
