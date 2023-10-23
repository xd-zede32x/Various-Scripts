using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    [SerializeField] private Text _text1;
    [SerializeField] private Text _text2;
    [SerializeField] private Text _text3;

    private void Start()
    {
        WorkingTheText();
    }

    private void WorkingTheText()
    {
        _text1.DOText("Hi", 3);

        _text1.DOText("Xd", 3).SetRelative();
        _text2.DOText("я взломал этот текст", 5, true, ScrambleMode.All);

        _text2.DOText("My name", 3);
        _text3.DOText("Roman", 3);

        _text1.DOColor(Color.red, 5);
        _text2.DOColor(Color.red, 5);
        _text3.DOColor(Color.red, 5);
    }
}