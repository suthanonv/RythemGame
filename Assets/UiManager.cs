using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public enum GameStat
{ 
GameOver,Victory
}



public class UiManager : MonoBehaviour
{
    public static UiManager instnace;


    [SerializeField] TextMeshProUGUI GameEndTitle;
    private void Awake()
    {
        instnace = this;
    }

  [SerializeField]  List<GameObject> SceneToOpen = new List<GameObject>();

    public void OpenScene(int index)
    {
        foreach(GameObject i in SceneToOpen)
        {
            i.SetActive(false);
        }
        SceneToOpen[index].SetActive(true);
    }


    public void GameEndUI(GameStat GameEnd)
    {
        if(GameEnd == GameStat.GameOver)
        {
            GameEndTitle.text = GameEnd.ToString();
            GameEndTitle.color = Color.red;
        }
        else
        {
            GameEndTitle.text = GameEnd.ToString();
            GameEndTitle.color = Color.green;
        }
    }


}
