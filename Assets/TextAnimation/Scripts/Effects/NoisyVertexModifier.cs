using System;
using UnityEngine;
using System.Collections;
using TextAnimation;
using TextAnimation.Effects;
using Random = UnityEngine.Random;

namespace TextAnimation.Effects
{
    public class NoisyVertexModifier : BaseVertexModifier
    {
        [SerializeField]
        private AnimationCurve forceCurve;
        [SerializeField]
        private float rangeAmount = 10;

        public override void Apply(CharController charController, ref UIVertex uiVertex)
        {
            float parsedAmount = rangeAmount * forceCurve.Evaluate(charController.Progress);
            uiVertex.position.x = uiVertex.position.x + Random.Range(-parsedAmount, parsedAmount);
        }
    }
}