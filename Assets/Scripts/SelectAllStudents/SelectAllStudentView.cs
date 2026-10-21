using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectAllStudentView : MonoBehaviour
{
    [SerializeField] private Button sendButton;
    [SerializeField] private TextMeshProUGUI textField;
    private SelectAllStudentController controller;


    private void Awake()
    {
        controller = GetComponent<SelectAllStudentController>();
    }
    void Start()
    {
        sendButton.onClick.AddListener(OnSendButtonClicked);
    }
    void OnSendButtonClicked()
    {
        controller.SendRequest(OnCallback);
    }

    void OnCallback(StudentArrayModel array)
    {
        textField.text = "";
        foreach (var student in array.data)
        {
            textField.text+=$"{student.name} - {student.lastname}\n";
        }
    }
}
