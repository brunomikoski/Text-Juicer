using UnityEngine;

namespace BrunoMikoski.TextJuicer.Effects
{
    [AddComponentMenu("UI/Text Juicer/Effects/Color")]
    public class ColorModifier : VertexModifier
    {
        [SerializeField]
        private AnimationCurve curve = new AnimationCurve(new Keyframe(0, 0));
        [SerializeField]
        private Color[] colors;
        public override void Apply(CharacterData characterData, ref UIVertex uiVertex)
        {
            Color targetColor = colors[characterData.Order%colors.Length];
            Color currentColor = uiVertex.color;


            targetColor = targetColor*curve.Evaluate(characterData.Progress);
            currentColor = currentColor*(1f - curve.Evaluate(characterData.Progress));

            uiVertex.color = currentColor + targetColor;
        }
   }
}