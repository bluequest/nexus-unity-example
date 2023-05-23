using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UI_Referrals : MonoBehaviour
{
    public Button CopyCodeBtn;
    public TextMeshProUGUI localReferralCode;


    void OnEnable()
    {
        CopyCodeBtn.onClick.AddListener(() => HandleCopyCodeButtonClick());
    }
    void OnDisable()
    {
        CopyCodeBtn.onClick.RemoveAllListeners();
    }


    void HandleCopyCodeButtonClick()
    {
        TextEditor te = new TextEditor();
        te.text = localReferralCode.text;
        te.SelectAll();
        te.Copy();
    }
}
