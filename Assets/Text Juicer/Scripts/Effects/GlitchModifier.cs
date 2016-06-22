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

        public override void Apply(CharacterData characterData, ref UIVertex uiVertex)
        {
            float parsedAmount = rangeAmount * forceCurve.Evaluate(characterData.Progress);
            uiVertex.position.x = uiVertex.position.x + Random.Range(-parsedAmount, parsedAmount);
        }
    }
}