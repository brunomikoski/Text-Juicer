using UnityEngine;

public class AddColorVertexModifier : BaseVertexModifier
{
    [SerializeField]
    private AnimationCurve curve;
    [SerializeField]
    private Color color;

    public override void Apply(float progress, ref UIVertex uiVertex)
    {
        uiVertex.color = curve.Evaluate(progress) * color;
    }

}