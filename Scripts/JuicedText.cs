using BrunoMikoski.TextJuicer.Effects;
using UnityEngine;
using UnityEngine.UI;

namespace BrunoMikoski.TextJuicer
{
    [RequireComponent(typeof (Text))]
    [AddComponentMenu("UI/Text Juicer/Juiced Text")]
    public class JuicedText : BaseMeshEffect
    {
        public const string VERSION = "0.0.2";

        [SerializeField]
        private float duration = 1.0f;
        [SerializeField]
        private float delay = 0.01f;
        [SerializeField, Range(0.0f, 1.0f)]
        private float progress;
        [SerializeField]
        private bool playOnEnable = true;
        [SerializeField]
        private bool loop = false;
        [SerializeField]
        private bool playForever = false;

        private CharacterData[] charactersData;
        private float internalTime;
        private bool isDirty;
        private float lastInternalTime;
        private float realTotalAnimationTime;

        private Text textComponent;
        public Text TextComponent
        {
            get
            {
                if (textComponent == null)
                {
                    SetDirty();
                    UpdateComponents();
                }
                return textComponent;
            }
        }

        private VertexModifier[] vertexModifiers;
        private bool isPlaying;

#if UNITY_EDITOR
        protected override void OnValidate()
        {
            SetDirty();
            base.OnValidate();
        }
#endif

        protected override void OnEnable()
        {
            base.OnEnable();
            SetDirty();
            if (Application.isPlaying && playOnEnable)
                Play();
        }

        public override void ModifyMesh(VertexHelper vh)
        {
            int count = vh.currentVertCount;
            if (!IsActive() || count == 0 || isDirty)
            {
                vh.Clear();
                return;
            }

            int characterCount = 0;
            for (int i = 0; i < count; i += 4)
            {
                if (characterCount >= charactersData.Length)
                {
                    vh.Clear();
                    SetDirty();
                    return;
                }

                CharacterData characterData = charactersData[characterCount];
                for (int j = 0; j < 4; j++)
                {
                    UIVertex uiVertex = new UIVertex();
                    vh.PopulateUIVertex(ref uiVertex, i + j);

                    ModifyVertex(characterData, ref uiVertex);

                    vh.SetUIVertex(uiVertex, i + j);
                }
                characterCount += 1;
            }
        }

        private void ModifyVertex(CharacterData characterData, ref UIVertex uiVertex)
        {
            for (int i = 0; i < vertexModifiers.Length; i++)
            {
                VertexModifier vertexModifier = vertexModifiers[i];
                vertexModifier.Apply(characterData, ref uiVertex);
            }
        }

        public void Complete()
        {
            if (isPlaying)
                progress = 1.0f;
        }

        public void Restart()
        {
            internalTime = 0;
            SetDirty();
        }

        public void Play(bool fromBeginning = true)
        {
            if (fromBeginning)
                Restart();

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
                if (internalTime + Time.deltaTime <= realTotalAnimationTime || playForever)
                {
                    internalTime += Time.deltaTime;
                }
                else
                {
                    if (loop)
                    {
                        internalTime = 0;
                    }
                    else
                    {
                        internalTime = realTotalAnimationTime;
                        progress = 1.0f;
                        Stop();
                    }
                }
            }
        }

        private void UpdateTime()
        {
            if (!isPlaying)
            {
                internalTime = progress * realTotalAnimationTime;
            }
            else
            {
                progress = internalTime / realTotalAnimationTime;
            }

            for (int i = 0; i < charactersData.Length; i++)
                charactersData[i].UpdateTime(internalTime);

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
                if(textComponent == null)
                    textComponent = GetComponent<Text>();
                vertexModifiers = GetComponents<VertexModifier>();

                int charCount = textComponent.text.Length;
                charactersData = new CharacterData[charCount];

                realTotalAnimationTime = duration +
                                         (charCount * delay);

                for (int i = 0; i < charCount; i++)
                {
                    charactersData[i] = new CharacterData(delay * i,
                        duration, i);
                }

                isDirty = false;
            }
        }

        public void SetDirty()
        {
            isDirty = true;
        }

        public void SetProgress(float targetProgress)
        {
            SetDirty();
            UpdateComponents();
            progress = targetProgress;
            internalTime = progress * realTotalAnimationTime;
        }

        public void SetPlayForever(bool shouldPlayForever)
        {
            playForever = shouldPlayForever;
        }
    }
}
