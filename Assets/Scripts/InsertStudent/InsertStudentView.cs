using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InsertStudentView : MonoBehaviour
{
    [SerializeField] private Button sendButton;
    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private TMP_InputField lastNameInputField;

    private InsertStudentController controller;


    private void Awake()
    {
        controller = GetComponent<InsertStudentController>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sendButton.onClick.AddListener(OnSendButtonClicked);
    }
    void OnSendButtonClicked()
    {
        controller.SendRequest(nameInputField.text, lastNameInputField.text);
    }
}
