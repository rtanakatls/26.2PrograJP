using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class InsertStudentController : MonoBehaviour
{

    private const string url = "http://localhost/prograjp262/library/insert_student.php";

    public void SendRequest(string name, string lastName)
    {
        StartCoroutine(Send(name,lastName ));
    }

    private IEnumerator Send(string name, string lastName)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", name);
        form.AddField("lastname", lastName);

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();
            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Se insertó con éxito");
            }
            else
            {
                Debug.LogError("Error: " + www.error);
            }
        }
    }
}
