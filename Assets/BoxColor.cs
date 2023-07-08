using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColor : MonoBehaviour
{
    public notetype NoteTypeOFBox;
    SpriteRenderer thisbox;

    private void Start()
    {
        thisbox = this.GetComponent<SpriteRenderer>();
        thisbox.color = NoteManageMent.instance.NoteColor[(int)NoteTypeOFBox];
    }

}
