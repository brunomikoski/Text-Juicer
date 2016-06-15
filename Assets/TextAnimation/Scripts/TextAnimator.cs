using UnityEngine;
using UnityEngine.UI;


public class TextAnimator : BaseMeshEffect
{
    [SerializeField]
    private float perCharacterAnimationTime = 1.0f;

    [SerializeField]
    private float perCharacterAnimationDelay = 0.01f;

    [SerializeField]
    private bool animate;

    [SerializeField, Range(0.0f,1.0f)]
    private float progress;

    private float animationTime = 0;
    private bool isAnimating;
    private Text textComponent;
    private CharacterController[] characterControllers;
    private BaseCharacterModifier[] characterModifiers;

    protected override void OnValidate()
    {
        textComponent = GetComponent<Text>();
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

                if (isAnimating)
                {
                    CharacterController characterController = characterControllers[characterCount];
                    ModifyVertex(characterController, ref uiVertex);
                }

                //uiVertex.position.y += curveForText.Evaluate(rectTrans.rect.width * rectTrans.pivot.x + uiVertex.position.x) * curveMultiplier;
                vh.SetUIVertex(uiVertex, i + j);
            }
            characterCount += 1;
        }
    }

    private void ModifyVertex(CharacterController characterController, ref UIVertex uiVertex)
    {
        for (int i = 0; i < characterModifiers.Length; i++)
        {
            BaseCharacterModifier baseCharacterModifier = characterModifiers[i];
            baseCharacterModifier.Apply(characterController.Progress, ref uiVertex);
        }
    }

    private void Update()
    {
        if (animate)
        {
            animate = false;
            animationTime = 0;

            characterControllers = new CharacterController[textComponent.text.Length];

            for (int i = 0; i < textComponent.text.Length; i++)
                characterControllers[i] = new CharacterController(perCharacterAnimationTime, perCharacterAnimationDelay*i);

            characterModifiers = GetComponents<BaseCharacterModifier>();

            isAnimating = true;

        }

        if (isAnimating)
        {
            animationTime += Time.deltaTime;

            float lastProgress = 0;
            for (int i = 0; i < characterControllers.Length; i++)
            {
                characterControllers[i].UpdateTime(animationTime);
                lastProgress = characterControllers[i].Progress;
            }

            graphic.SetAllDirty();

            if (lastProgress >= 1.0f)
                isAnimating = false;
        }
    }
}
