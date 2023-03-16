using System;
using System.Collections;
using Gameplay;
using UnityEngine;
using Zenject;

public class TimerTest : MonoBehaviour
{
    [Inject] private Timer _timer;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);

        _timer.StartTimer(125);
        
        _timer.onElapsed += () => Debug.Log("Elapsed");
    }
}
