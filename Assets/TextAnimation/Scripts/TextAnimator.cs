using TextAnimation.Effects;
using UnityEngine;
using UnityEngine.UI;

namespace TextAnimation
{
    [RequireComponent(typeof(Text))]
    public class TextAnimator : BaseMeshEffect
    {
        [SerializeField]
        private float perCharacterAnimationTime = 1.0f;

        [SerializeField]
        private float perCharacterAnimationDelay = 0.01f;

        [SerializeField, Range(0.0f, 1.0f)]
        private float progress;

        private CharController[] charControllers;
        private float internalTime;
        private bool isDirty;
        private float lastInternalTime;
        private float realTotalAnimationTime;

        private Text textComponent;
        private BaseVertexModifier[] vertexModifiers;
        private bool isPlaying;

        protected override void OnValidate()
        {
            SetDirty();
            base.OnValidate();
        }

        public override void ModifyMesh(VertexHelper vh)
        {
            int count = vh.currentVertCount;
            if (!IsActive() || count == 0 || isDirty)
                return;

            if(isDirty)
                return;

            int characterCount = 0;
            for (int i = 0; i < count; i += 4)
            {
                if (characterCount >= charControllers.Length)
                {
                    SetDirty();
                    return;
                }

                CharController charController = charControllers[characterCount];
                for (int j = 0; j < 4; j++)
                {
                    UIVertex uiVertex = new UIVertex();
                    vh.PopulateUIVertex(ref uiVertex, i + j);

                    ModifyVertex(charController, ref uiVertex);

                    vh.SetUIVertex(uiVertex, i + j);
                }
                characterCount += 1;
            }
        }


        private void ModifyVertex(CharController charController, ref UIVertex uiVertex)
        {
            for (int i = 0; i < vertexModifiers.Length; i++)
            {
                BaseVertexModifier baseVertexModifier = vertexModifiers[i];
                baseVertexModifier.Apply(charController, ref uiVertex);
            }
        }

        public void Complete()
        {
            if(isPlaying)
                progress = 1.0f;
        }

        public void Restart()
        {
            internalTime = 0;
        }
        public void Play()
        {
            isPlaying = true;
        }

        public void Stop()
        {
            isPlaying = false;
        }

        private void Update()
        {
            UpdateComponents();
            UpdateTime();
            CheckAnimation();
        }

        private void CheckAnimation()
        {
            if (isPlaying)
            {
                if (internalTime + Time.deltaTime <= realTotalAnimationTime)
                {
                    internalTime += Time.deltaTime;
                }
                else
                {
                    internalTime = realTotalAnimationTime;
                    progress = 1.0f;
                    Stop();
                }
            }
        }

        private void UpdateTime()
        {
            if (!isPlaying)
            {
                internalTime = progress*realTotalAnimationTime;
            }
            else
            {
                progress = internalTime / realTotalAnimationTime;
            }

            

            for (int i = 0; i < charControllers.Length; i++)
                charControllers[i].UpdateTime(internalTime);

            if (internalTime != lastInternalTime)
            {
                lastInternalTime = internalTime;
                graphic.SetAllDirty();
            }
        }

        private void UpdateComponents()
        {
            if (isDirty)
            {
                textComponent = GetComponent<Text>();
                vertexModifiers = GetComponents<BaseVertexModifier>();


                int charCount = textComponent.text.Length;
                charControllers = new CharController[charCount];


                realTotalAnimationTime = perCharacterAnimationTime +
                                         (charCount*perCharacterAnimationDelay);


                for (int i = 0; i < charCount; i++)
                {
                    charControllers[i] = new CharController(perCharacterAnimationDelay*i,
                        perCharacterAnimationTime, i);
                }

                isDirty = false;
            }
        }

        public void SetDirty()
        {
            isDirty = true;
        }
    }
}
