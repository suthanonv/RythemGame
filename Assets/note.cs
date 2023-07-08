using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum notetype
{ 
one,two,three,four
}


public class note : MonoBehaviour
{

    public notetype thisnotetype;
    int index;
    public void chagnelayer(float x)
    {
        this.transform.position = new Vector2(x, this.transform.position.y);
    }

    public void SetLayer(int newindex)
    {
        index = newindex;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<BoxColor>() != null)
        {
            if (collision.gameObject.GetComponent<BoxColor>().NoteTypeOFBox == thisnotetype)
            {
                Debug.Log("Correct Note");
            }
            Destroy(this.gameObject);
        }
    }


    private void OnDestroy()
    {
        Spawing.instance.DelegateLayer[index].RemoveListener(chagnelayer);
    }
}
