using UnityEngine;

namespace TextAnimation.Effects
{
    [RequireComponent(typeof(TextAnimator))]
    public abstract class BaseVertexModifier : MonoBehaviour
    {
        private TextAnimator textAnimator;

        private void OnValidate()
        {
            if (textAnimator == null)
                textAnimator = GetComponent<TextAnimator>();

            textAnimator.SetDirty();
        }
        public abstract void Apply(CharController charController, ref UIVertex uiVertex);
    }
}