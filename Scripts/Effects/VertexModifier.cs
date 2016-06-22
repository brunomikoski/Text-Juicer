using UnityEngine;

namespace BrunoMikoski.TextJuicer.Effects
{
    [RequireComponent(typeof(JuicedText))]
    public abstract class VertexModifier : MonoBehaviour
    {
        private JuicedText juicedText;

        private void OnValidate()
        {
            if (juicedText == null)
                juicedText = GetComponent<JuicedText>();

            juicedText.SetDirty();
        }
        public abstract void Apply(CharacterData characterData, ref UIVertex uiVertex);
    }
}