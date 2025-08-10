using UnityEngine;

public class QuestioningGameScript : MonoBehaviour
{
    public bool correctlyAnswered;
    void OnEnable()
    {
        GameManager.instance.entryGameplay.questioningGameScript = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HowDidTheyAnswer(bool result)
    {
        correctlyAnswered = result;
    }
}
