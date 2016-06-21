using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Button))]
public class UpdateTextButton : MonoBehaviour
{
    [SerializeField]
    private Text targetTextComponent;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void OnDestroy()
    {
        button.onClick.RemoveAllListeners();
    }

    private void OnClick()
    {
        targetTextComponent.text = "Random New Text: " + Random.Range(0, 1000);
    }
}
