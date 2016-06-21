using UnityEngine;

namespace TextAnimation.Effects
{
    public class XVertexModifier : BaseVertexModifier
    {
        [SerializeField]
        private AnimationCurve curve = new AnimationCurve(new Keyframe(0, 1));

        public override void Apply(CharController charController, ref UIVertex uiVertex)
        {
            uiVertex.position.x *= curve.Evaluate(charController.Progress);
        }
    }
}