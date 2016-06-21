using UnityEngine;

namespace TextAnimation.Effects
{
    public class AddColorVertexModifier : BaseVertexModifier
    {
        [SerializeField]
        private AnimationCurve curve;
        [SerializeField]
        private Color color;

        public override void Apply(CharController charController, ref UIVertex uiVertex)
        {
            uiVertex.color = curve.Evaluate(charController.Progress) * color;
        }

    }
}