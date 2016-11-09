namespace BrunoMikoski.TextJuicer
{
    public struct CharacterData
    {
        private float progress;

        public float Progress
        {
            get { return progress; }
        }

        private float startingTime;

        private float totalAnimationTime;
        private int order;

        public int Order
        {
            get { return order; }
        }

        public CharacterData(float startTime, float targetAnimationTime, int targetOrder)
        {
            progress = 0.0f;
            startingTime = startTime;
            totalAnimationTime = (startingTime + targetAnimationTime) - startTime;
            order = targetOrder;
        }

        public void UpdateTime(float time)
        {
            if (time < startingTime)
                return;

            progress = (time - startingTime) / totalAnimationTime;
        }
    }
}
