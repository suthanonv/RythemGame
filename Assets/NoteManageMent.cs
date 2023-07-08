using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManageMent : MonoBehaviour
{
    public static NoteManageMent instance;

    public List<Color> NoteColor = new List<Color>();

    private void Awake()
    {
        instance = this;
    }

    public KeyCode postiveKey = KeyCode.D;
    public KeyCode negativeKey = KeyCode.A;



    private void Update()
    {
        if(Input.GetKeyDown(postiveKey))
        {
            Spawing.instance.sorttingpositive();
        }

        if(Input.GetKeyDown(negativeKey))
        {
            Spawing.instance.sortingnegative();
        }
    }
}
