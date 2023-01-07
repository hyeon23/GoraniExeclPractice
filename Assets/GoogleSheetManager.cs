using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GoogleSheetManager : MonoBehaviour
{
    ///export?format=tsv
    //const string URL = "https://docs.google.com/spreadsheets/d/1qgcMc4niI7E-3IZ3sdvRAxrOT8iWbQnr2XQaXQ9PkI8/export?format=tsv&gid=1447366619";
    //&range=A2:B
    //const string URL = "https://script.google.com/macros/s/AKfycbxE37zwp2KMshcWmA11xB1g3QjpkASxO-zqJ2kAGRUfBPUy-LnWPQh1qFhpvZarKnyxeg/exec";

    //IEnumerator Start()
    //{
    //    UnityWebRequest www = UnityWebRequest.Get(URL);
    //    yield return www.SendWebRequest();

    //    string data = www.downloadHandler.text;
    //    print(data);
    //}

    //IEnumerator Start()
    //{
    //    WWWForm form = new WWWForm();//Post 데이터 전송 시, 값을 키와 값으로 전송해주는 형태
    //    form.AddField("value", "값");

    //    //UnityWebRequest www = UnityWebRequest.Get(URL);//값을 가져오는 함수
    //    UnityWebRequest www = UnityWebRequest.Post(URL, form);//값을 가져오는 함수
    //    yield return www.SendWebRequest();

    //    string data = www.downloadHandler.text;
    //    print(data);
    //}

    const string URL = "";
    public TMP_InputField IDInput, PassInput;
    string id, pass;

    IEnumerator Start()
    {
        WWWForm form = new WWWForm();
        form.AddField("value", "값");

        UnityWebRequest www = UnityWebRequest.Post(URL, form);
        yield return www.SendWebRequest();

        string data = www.downloadHandler.text;
    }

    bool SetIDPass()
    {
        id = IDInput.text.Trim();
        pass = PassInput.text.Trim();

        if (id == "" || pass == "") return false;
        else return true;
    }

    public void Register()
    {
        if (!SetIDPass())
        {
            print("아이디 또는 비밀번호가 비어있습니다.");
            return;
        }
        WWWForm form = new WWWForm();
        form.AddField("order", "register");
        form.AddField("id", id);
        form.AddField("pass", pass);

        StartCoroutine(Post(form));
    }

    IEnumerator Post(WWWForm form)
    {
        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();

            if (www.isDone) print(www.downloadHandler.text);
            else print("웹의 응답이 없습니다.");
        }
    }
}
