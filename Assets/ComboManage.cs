using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ComboManage : MonoBehaviour
{
    public static ComboManage instance;

    [SerializeField] float TextTime;
    [SerializeField] TextMeshProUGUI ComBoText;
    int currentCombo = 0;
    int hightCombo;
    Coroutine OffTextCoro;

    private void Awake()
    {
        instance = this;
    }

    public void Combo()
    {
        currentCombo++;
        if (currentCombo > hightCombo) hightCombo = currentCombo;
        ComBoText.text = currentCombo.ToString();
      if (OffTextCoro == null )     OffTextCoro = StartCoroutine(OffText(TextTime));
    }


    IEnumerator OffText(float Time)
    {
        yield return new WaitForSeconds(Time);
        ComBoText.text = "";
    }

    public void ResetCombo()
    {
        int lastcombo = currentCombo;
        currentCombo = 0;
        if (lastcombo > 0)
        {
            ComBoText.text = currentCombo.ToString();
            if (OffTextCoro == null) OffTextCoro = StartCoroutine(OffText(TextTime));
        }
        else
        {
            ComBoText.text = "";
        }
    }
}
