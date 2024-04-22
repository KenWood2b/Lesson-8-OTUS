using UnityEngine;

namespace Utils
{
    /*
     * позволяет запускать таймер (тип доступа protected!!!) выбрав случайным образом время задержки
     * в диапазоне (_minDelay, _maxDelay) включительно обе границы
     */
    public class TimerRandomDelay : Timer
    {
        private readonly float _minDelay;
        private readonly float _maxDelay;

        public TimerRandomDelay(float minDelay, float maxDelay, float deltaTime) : base(default, deltaTime)
        {
            _minDelay = minDelay;
            _maxDelay = maxDelay;
        }

        protected override void StartTimer()
        {
            _delay = Random.Range(_minDelay, _maxDelay);
            base.StartTimer();
        }
    }
}
