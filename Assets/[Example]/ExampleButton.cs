using UnityEngine;
using TextAnimation;
using UnityEngine.UI;

[RequireComponent(typeof(Button), typeof(TextAnimator))]
public class ExampleButton : MonoBehaviour
{
    private Button button;
    private TextAnimator textAnimation;

    private void Awake()
    {
        button = GetComponent<Button>();
        textAnimation = GetComponent<TextAnimator>();

        button.onClick.AddListener(OnClickButton);
    }

    private void OnDestroy()
    {
        button.onClick.RemoveAllListeners();
    }

    private void OnClickButton()
    {
        textAnimation.Play();
    }
}
