using UnityEngine;

namespace BrunoMikoski.TextJuicer.Effects
{
    [AddComponentMenu("UI/Text Juicer/Effects/Scale")]
    public class ScaleModifier : VertexModifier
    {
        [SerializeField]
        private AnimationCurve curve = new AnimationCurve(new Keyframe(0, 1));
        public override void Apply(CharController charController, ref UIVertex uiVertex)
        {
            uiVertex.position.y = curve.Evaluate(charController.Progress)*uiVertex.position.y;
            uiVertex.position.x = curve.Evaluate(charController.Progress) *uiVertex.position.x;

        }
    }
}