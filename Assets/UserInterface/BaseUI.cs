using UnityEngine;
using UnityEngine.UIElements;

public class BaseUI : MonoBehaviour
{
    UIDocument uiDocument;
    Button startButton;

    void OnEnable()
    {
        uiDocument = GetComponent<UIDocument>();

        startButton = uiDocument.rootVisualElement.Q("StartButton") as Button;

        startButton.RegisterCallback<ClickEvent>(OnStart);
    }

    public void OnStart(ClickEvent args)
    {
        Debug.Log("Clicked");
    }
}
