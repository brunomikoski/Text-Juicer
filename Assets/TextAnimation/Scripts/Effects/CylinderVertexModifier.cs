using UnityEngine;

namespace TextAnimation.Effects
{
    /// <summary>
    ///     Based on this file
    ///     https://bitbucket.org/ddreaper/unity-ui-extensions/src/2689f3d6ce7d41fe9caaa3025c9f1ebfe65b4a7f/Scripts/Effects/CylinderText.cs
    /// </summary>
    public class CylinderVertexModifier : BaseVertexModifier
    {
        [SerializeField]
        private float radius = 10;


        public override void Apply(CharController charController, ref UIVertex uiVertex)
        {
            float x = uiVertex.position.x;

            float finalRadius = Mathf.Clamp(radius*charController.Progress, 1, radius);
            uiVertex.position.z = -finalRadius*Mathf.Cos(x/finalRadius);
            uiVertex.position.x = finalRadius*Mathf.Sin(x/finalRadius);
        }
    }
}
