using UnityEngine;

namespace TextAnimation
{
    public struct CharController
    {
        private float progress;

        public float Progress
        {
            get { return progress; }
        }

        private float startingTime;

        private float internalTime;
        private float finalTime;
        private float totalAnimationTime;
        private int order;

        public int Order
        {
            get { return order; }
        }

        public CharController(float startTime, float targetAnimationTime, int targetOrder)
        {
            progress = 0.0f;
            startingTime = startTime;
            finalTime = startingTime + targetAnimationTime;
            totalAnimationTime = finalTime - startTime;
            internalTime = 0;
            order = targetOrder;
        }

        public void UpdateTime(float time)
        {
            if (time < startingTime)
                return;


            progress = Mathf.Clamp((time - startingTime)/totalAnimationTime, 0.0f, 1.0f);
        }
    }
}
