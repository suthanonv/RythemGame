using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadingScene : MonoBehaviour
{
    public void loadingScene(int index)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(index);
           }
}
