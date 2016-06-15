using UnityEngine;

public class AxixCharacterModifier : BaseCharacterModifier
{
    [SerializeField]
    private AnimationCurve curve;

    public override void Apply(float progress, ref UIVertex uiVertex)
    {
        uiVertex.position.y *= curve.Evaluate(progress);
    }
}
