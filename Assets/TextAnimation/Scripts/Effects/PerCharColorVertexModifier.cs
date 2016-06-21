using UnityEngine;

namespace TextAnimation.Effects
{
    public class PerCharColorVertexModifier : BaseVertexModifier
    {
        [SerializeField]
        private AnimationCurve curve = new AnimationCurve(new Keyframe(0, 0));
        [SerializeField]
        private Color[] colors;
        public override void Apply(CharController charController, ref UIVertex uiVertex)
        {
            Color targetColor = colors[charController.Order%colors.Length];
            Color currentColor = uiVertex.color;


            targetColor = targetColor*curve.Evaluate(charController.Progress);
            currentColor = currentColor*(1f - curve.Evaluate(charController.Progress));

            uiVertex.color = currentColor + targetColor;
        }
   }
}