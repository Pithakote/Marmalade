using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerModel : MonoBehaviour
{
    public delegate void TimerStoppedDelegate();
    public event TimerStoppedDelegate TimerStopped;
}
