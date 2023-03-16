using System;
using System.Collections;
using UnityEngine;
using Action = System.Action;

namespace Gameplay
{
    public class Timer : MonoBehaviour
    {
        private int _seconds;

        private bool _isStarted;

        private Coroutine _timerCoroutine;

        public event Action<int> onStarted;
        public event Action<int> onValueChanged;
        public event Action onElapsed;
        public event Action<int> onStoped;

        public void StartTimer(int seconds)
        {
            if (_isStarted)
            {
                Debug.Log("Timer is already started");
                return;
            }

            _seconds = seconds;

            StartTimerRoutine();

            onStarted?.Invoke(_seconds);
        }

        public void StopTimer()
        {
            if (_isStarted == false)
            {
                Debug.Log("Timer is not started");
                return;
            }

            StopTimerRoutine();

            onStoped?.Invoke(_seconds);
        }

        private void StartTimerRoutine()
        {
            if (_timerCoroutine == null)
            {
                _timerCoroutine = StartCoroutine(TimerRoutine());

                _isStarted = true;
            }
        }

        private void StopTimerRoutine()
        {
            if (_timerCoroutine != null)
            {
                StopCoroutine(_timerCoroutine);

                _timerCoroutine = null;

                _isStarted = false;
            }
        }

        private IEnumerator TimerRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);

                ProcessTimer();
            }
        }

        private void ProcessTimer()
        {
            if (_seconds > 0)
            {
                _seconds--;

                onValueChanged?.Invoke(_seconds);
                
                if (_seconds == 0)
                {
                    Stop();
                }
            }
            else
            {
                Stop();
            }

            void Stop()
            {
                StopTimerRoutine();

                onElapsed?.Invoke();
            }
        }
    }
}
