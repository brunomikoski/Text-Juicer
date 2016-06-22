using UnityEngine;

namespace BrunoMikoski.TextJuicer.Effects
{
    [AddComponentMenu("UI/Text Juicer/Effects/X")]
    public class XModifier : VertexModifier
    {
        [SerializeField]
        private AnimationCurve curve = new AnimationCurve(new Keyframe(0, 1));

        public override void Apply(CharController charController, ref UIVertex uiVertex)
        {
            uiVertex.position.x *= curve.Evaluate(charController.Progress);
        }
    }
}