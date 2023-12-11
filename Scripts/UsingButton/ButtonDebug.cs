using UnityEngine;
using UnityEngine.UI;

public class ButtonDebug : MonoBehaviour
{
    [SerializeField] private Button _buttonScript;
    [SerializeField] private Button _buttonUnityEvent;

    private float _someValue;

    private void OnEnable()
    {
        _buttonScript.onClick.AddListener(OnScriptButtonClick);
        _buttonUnityEvent.onClick.AddListener(OnUnityEventButtonClicked);
    }

    private void OnDisable()
    {
        _buttonScript.onClick.RemoveListener(OnScriptButtonClick);
        _buttonUnityEvent.onClick.RemoveListener(OnUnityEventButtonClicked);
    }

    private void OnScriptButtonClick()
    {
        _someValue += GetRandom(); 
        Debug.Log($"Button script clicked. Some value = {_someValue}");
    }

    private void OnUnityEventButtonClicked()
    {
        _someValue -= GetRandom();
        Debug.Log($"Button UnityEventClick. Some value = {_someValue}");
    }

    private int GetRandom()
    {
        return Random.Range(1, 5);
    }
}