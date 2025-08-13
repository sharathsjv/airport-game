using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuestioningGameScript : MonoBehaviour
{
    public EventSystem eventSystem;
    public Slider slider;
    public bool correctlyAnswered;
    void OnEnable()
    {
        if (eventSystem == null)
        {
            eventSystem = FindAnyObjectByType<EventSystem>();
            eventSystem.SetSelectedGameObject(GetComponentInChildren<Button>().gameObject);
            Debug.Log(eventSystem.firstSelectedGameObject = GetComponentInChildren<Button>().gameObject);
        }
        else
        {
            eventSystem.SetSelectedGameObject(GetComponentInChildren<Button>().gameObject);
            Debug.Log(eventSystem.firstSelectedGameObject = GetComponentInChildren<Button>().gameObject);
        }

        if (slider == null)
        {
            slider = GetComponentInChildren<Slider>();
        }
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
