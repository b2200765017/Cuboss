using System;
using UnityEngine;

public class UIAnimator : MonoBehaviour
{
    public static UIAnimator Instance;
    [SerializeField] private GameObject HowToMenu, HowToTextTitle, HowToText, ExitButton,
        GameOver,ScoreText, ScoreSC, TimeText, TimeScore, Restart, Home;

    [SerializeField] private CanvasGroup InGamePanel;
    private Vector3 UiScale =new Vector3(1,1,1), UiScale2 = new Vector3(6,6,6);

    private void Awake() {
        if (Instance != null && Instance != this) { 
            Destroy(this); 
        } 
        else { 
            Instance = this; 
        }
    }
    

    public void OnCanvasButtonEntered() {

        LeanTween.reset();
        LeanTween.scaleX(HowToMenu, 2, 0.4f).setEaseInOutQuad().setOnComplete(() =>
        {
            ExitButton.SetActive(true);
            HowToText.SetActive(true);
            HowToTextTitle.SetActive(true);
        });
    }   
    public void OnCanvasButtonExited() {
        LeanTween.reset();
        LeanTween.scaleX(HowToMenu, 0, 0.4f).setEaseInOutQuad().setOnStart(() =>
        {
            ExitButton.SetActive(false);
            HowToText.SetActive(false);
            HowToTextTitle.SetActive(false);
        });
    }

    public void OnGameEnd()
    {
        LeanTween.reset();
        LeanTween.alphaCanvas(InGamePanel, 1, 0.4f).setOnComplete(() =>
        {
            LeanTween.scale(ScoreText, UiScale2, 0.1f);
            LeanTween.scale(ScoreSC, UiScale2, 0.1f);
            LeanTween.scale(TimeText, UiScale2, 0.1f);
            LeanTween.scale(TimeScore, UiScale2, 0.1f);
            LeanTween.scale(Restart, UiScale, 0.1f);
            LeanTween.scale(Home, UiScale, 0.1f);
        });

    }
}
