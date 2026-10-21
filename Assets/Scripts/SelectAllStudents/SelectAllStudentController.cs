using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class SelectAllStudentController : MonoBehaviour
{
    private const string url = "http://localhost/prograjp262/library/select_all_students.php";

    public void SendRequest(Action<StudentArrayModel> callback)
    {
        StartCoroutine(Send(callback));
    }

    private IEnumerator Send(Action<StudentArrayModel> callback)
    {

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();
            if (www.result == UnityWebRequest.Result.Success)
            {
                callback?.Invoke(JsonUtility.FromJson<StudentArrayModel>(www.downloadHandler.text));
            }
            else
            {
                Debug.LogError("Error: " + www.error);
            }
        }
    }
}
