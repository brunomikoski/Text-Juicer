using UnityEngine;

public class AddColorCharacterModifier : BaseCharacterModifier
{
    [SerializeField]
    private AnimationCurve curve;
    [SerializeField]
    private Color color;

    public override void Apply(float progress, ref UIVertex uiVertex)
    {
        Color color1 = curve.Evaluate(progress) * color;
        uiVertex.color = color1;
    }
}