using UnityEngine;
using UnityEngine.UI;

public class TextAnimator : BaseMeshEffect
{
    [SerializeField]
    private float perCharacterAnimationTime = 1.0f;

    [SerializeField]
    private float perCharacterAnimationDelay = 0.01f;

    [SerializeField, Range(0.0f, 1.0f)]
    private float progress;

    private CharacterController[] characterControllers;
    private float internalTime;
    private bool isDirty;
    private float lastInternalTime;
    private float realTotalAnimationTime;

    private Text textComponent;
    private BaseVertexModifier[] vertexModifiers;
    private bool isPlaying;

    protected override void OnValidate()
    {
        isDirty = true;
        base.OnValidate();
    }

    public override void ModifyMesh(VertexHelper vh)
    {
        int count = vh.currentVertCount;
        if (!IsActive() || count == 0)
        {
            return;
        }
        int characterCount = 0;
        for (int i = 0; i < count; i += 4)
        {
            for (int j = 0; j < 4; j++)
            {
                UIVertex uiVertex = new UIVertex();
                vh.PopulateUIVertex(ref uiVertex, i + j);

                if (characterControllers != null && characterControllers.Length == textComponent.text.Length)
                {
                    CharacterController characterController = characterControllers[characterCount];
                    ModifyVertex(characterController, ref uiVertex);
                }
                vh.SetUIVertex(uiVertex, i + j);
            }
            characterCount += 1;
        }
    }

    private void ModifyVertex(CharacterController characterController, ref UIVertex uiVertex)
    {
        for (int i = 0; i < vertexModifiers.Length; i++)
        {
            BaseVertexModifier baseVertexModifier = vertexModifiers[i];
            baseVertexModifier.Apply(characterController.Progress, ref uiVertex);
        }
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
        ValidateComponents();
        UpdateTime();
        CheckAnimation();
    }

    private void CheckAnimation()
    {
        if (isPlaying)
        {
            internalTime += Time.deltaTime;

            if(internalTime >= realTotalAnimationTime)
                Stop();
        }
    }

    private void UpdateTime()
    {
        if(!isPlaying)
            internalTime = progress*realTotalAnimationTime;

        for (int i = 0; i < characterControllers.Length; i++)
            characterControllers[i].UpdateTime(internalTime);

        if (internalTime != lastInternalTime)
        {
            lastInternalTime = internalTime;
            graphic.SetAllDirty();
        }
    }

    private void ValidateComponents()
    {
        if (isDirty)
        {
            textComponent = GetComponent<Text>();
            vertexModifiers = GetComponents<BaseVertexModifier>();


            int charCount = textComponent.text.Length;
            characterControllers = new CharacterController[charCount];


            realTotalAnimationTime = perCharacterAnimationTime +
                                     (charCount*perCharacterAnimationDelay);


            for (int i = 0; i < charCount; i++)
            {
                characterControllers[i] = new CharacterController(perCharacterAnimationDelay*i,
                    perCharacterAnimationTime);
            }

            isDirty = false;
        }
    }
}
