using UnityEngine;

namespace BrunoMikoski.TextJuicer.Effects
{
    /// <summary>
    ///     Based on this file
    ///     https://bitbucket.org/ddreaper/unity-ui-extensions/src/2689f3d6ce7d41fe9caaa3025c9f1ebfe65b4a7f/Scripts/Effects/CylinderText.cs
    /// </summary>
    [AddComponentMenu("UI/Text Juicer/Effects/Cylinder")]
    public class CylinderModifier : VertexModifier
    {
        [SerializeField]
        private float radius = 10;


        public override void Apply(CharacterData characterData, ref UIVertex uiVertex)
        {
            float x = uiVertex.position.x;

            float finalRadius = Mathf.Clamp(radius*characterData.Progress, 1, radius);
            uiVertex.position.z = -finalRadius*Mathf.Cos(x/finalRadius);
            uiVertex.position.x = finalRadius*Mathf.Sin(x/finalRadius);
        }
    }
}
