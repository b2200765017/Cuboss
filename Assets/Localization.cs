using System;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Localization : MonoBehaviour
{
    private TextMeshProUGUI _Text;

    [SerializeField] private string TrText;
    [SerializeField] private string EnText;
    private void Start()
    {
        _Text = GetComponent<TextMeshProUGUI>();
        LanguageManager.Instance.OnLanguageChange += ChangeString;
        ChangeString(this, EventArgs.Empty);
    }

    public void ChangeString(object sender, EventArgs e)
    {
        if (LanguageManager.Instance.CurrentLanguage == Language.English)
        {
            _Text.text = EnText;
        }
        else
        {
            _Text.text = TrText;
        }
    }
}
