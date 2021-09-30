using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipIntro : MonoBehaviour
{
    public string tipID;
    public string answer;

    [SerializeField] Text field;
    [SerializeField] Text answerField;
    public GameObject button;
    bool isNear;

    void OnEnable()
    {
        GetComponent<Animation>().Play("introTipAppear");
        field.text = GamesManager.Instance.texts.GetText(tipID);
        answerField.text = GamesManager.Instance.texts.GetText(answer);
        answerField.enabled = false;
        isNear = false;
    }
    void OnNear()
    {
        isNear = true;
        GetComponent<Animation>().Play("introTipOn");
    }
    public void OnPressed()
    {
        if (!isNear)
            OnNear();
        else
            Go();
    }
    void Go()
    {
        GetComponentInParent<ArExperience>().GotoGame();
    }
}
