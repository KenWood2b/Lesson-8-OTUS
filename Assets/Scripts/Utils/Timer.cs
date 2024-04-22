using System;

namespace Utils
{   
    public class Timer
    {
        protected float _delay;
        private readonly float _deltaTime;
        private float _remainingTime;
        private bool _running;

        public Timer(float delay, float deltaTime)
        {
            _delay = delay;
            _deltaTime = deltaTime;
        }
 
        public bool IsTimeFinish()
        {
            /*
             * Запускает обратный таймер на время _delay, если он не запущен.
             * Если запущен уменьшает время осташееся время на _deltaTime
             * Возвращает true если заданной время прошло
             */
            if(_running)
            {
                Tick();
            }
            else
            {
                StartTimer();
            }
            return _remainingTime < 0;
        }

        protected virtual void StartTimer()
        {
            _running = true;
            _remainingTime = _delay;
        }

        private void Tick()
        {
            _remainingTime -= _deltaTime;
        }

        public void ResetTimer()
        {
            /*
             * сбрасывает таймер в начальное состояние
             */
            _running = false;
            
        }
    }
}