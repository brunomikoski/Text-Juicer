using UnityEngine;
using Random = UnityEngine.Random;

namespace BrunoMikoski.TextJuicer.Effects
{
    [AddComponentMenu("UI/Text Juicer/Effects/Glitch")]
    public class GlitchModifier : VertexModifier
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