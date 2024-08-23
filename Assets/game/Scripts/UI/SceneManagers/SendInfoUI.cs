using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SendInfoUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField input_Name;
    [SerializeField] private TMP_InputField input_Email;
    [SerializeField] private TMP_InputField input_PhoneNumber;
    [SerializeField] private TMP_InputField input_CompanyName;
    [SerializeField] private Button button_Send;
    [SerializeField] private Button button_BackToMainMenu;

    [SerializeField] private WindowUI succesUI;
    [SerializeField] private WindowUI failUI;

    public void Start()
    {
        button_Send.onClick.AddListener(() =>
        {
            TrySendInfo();
        });

        button_BackToMainMenu.onClick.AddListener(() =>
        {
            GameManager.LOAD_MAIN_MENU();
        });
    }

    public void TrySendInfo() { 
        StartCoroutine(SendData());
    }

    IEnumerator SendData() {
        WWWForm form = new WWWForm();
        form.AddField("name", input_Name.text);
        form.AddField("email", input_Email.text);
        form.AddField("phonenumber", input_PhoneNumber.text);
        form.AddField("companyname", input_CompanyName.text);

        //       using UnityWebRequest www = UnityWebRequest.Post("https://server", form);
        //       yield return www.SendWebRequest();
        
        yield return new WaitForSeconds(2);
        succesUI.SetActive(true);

        Debug.Log(
            "name" + input_Name.text + "\n " +
            "email" + input_Email.text + "\n " +
            "phonenumber" + input_PhoneNumber.text + "\n " +
            "companyname" + input_CompanyName.text
            );
        /*
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(www.error);
        }
        */

    }

}
