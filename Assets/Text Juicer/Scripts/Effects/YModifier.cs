using UnityEngine;

namespace BrunoMikoski.TextJuicer.Effects
{
    [AddComponentMenu("UI/Text Juicer/Effects/Y")]
    public class YModifier : VertexModifier
    {
        [SerializeField]
        private AnimationCurve curve = new AnimationCurve(new Keyframe(0,1));

        public override void Apply(CharacterData characterData, ref UIVertex uiVertex)
        {
            uiVertex.position.y *= curve.Evaluate(characterData.Progress);
        }
    }
}