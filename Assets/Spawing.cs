using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
public class Spawing : MonoBehaviour
{
    [SerializeField] List<SpawningPattern> patterntospawn = new List<SpawningPattern>();
    [SerializeField] note NotePrefab;

    [SerializeField] List<Transform> SpawningPoint = new List<Transform>();

    public static Spawing instance;

    public List<UnityEvent<float>> DelegateLayer = new List<UnityEvent<float>>();

    List<note> NotePool = new List<note>();
    [SerializeField] int poolAmount;
    private void Awake()
    {
        instance = this;
    }

    void SpawnPool()
    {
        for(int i =0; i< poolAmount;i++)
        {
            note newNOte = Instantiate(NotePrefab, new Vector2(100, 100),Quaternion.identity);
            newNOte.gameObject.SetActive(false);
            NotePool.Add(newNOte);
        }
    }


    private void Start()
    {
        SpawnPool();
        StartCoroutine(StartPattern());
    }

    IEnumerator StartPattern()
    {
        int count = 0;

        while (count < patterntospawn.Count)
        {
            foreach (NoteToSpawn i in patterntospawn[count].AllNote)
            {
                if (i.IsHaveNote)
                {
                    note NewNote = NotePool.FirstOrDefault(i => i.gameObject.activeSelf == false);
                    NewNote.transform.position = SpawningPoint[i.LayerToSpawn].transform.position;
                    NewNote.thisnotetype = i.typeofNote;
                    NewNote.GetComponent<SpriteRenderer>().color = NoteManageMent.instance.NoteColor[(int)NewNote.thisnotetype];
                    NewNote.SetLayer(i.LayerToSpawn);
                    DelegateLayer[i.LayerToSpawn].AddListener(NewNote.chagnelayer);
                    NewNote.gameObject.SetActive(true);
                }
            }
           
          if(count < patterntospawn.Count)
            yield return new WaitForSeconds(patterntospawn[count].delayToNextPattern);

            count++;
        }
    }

    public void sortingnegative()
    {
        Transform temp = SpawningPoint[0];
        for (int i = 0; i < (SpawningPoint.Count - 1); i++) SpawningPoint[i] = SpawningPoint[i + 1];
        SpawningPoint[SpawningPoint.Count - 1] = temp;
        loadNewLayer();
    }

    void loadNewLayer()
    {
        for(int i =0; i < DelegateLayer.Count;)
        {
            DelegateLayer[i].Invoke(SpawningPoint[i].transform.position.x);
            i++;
        }
    }

    public void sorttingpositive()
    {
        Transform temp = SpawningPoint[SpawningPoint.Count - 1];
        for (int i = (SpawningPoint.Count - 2); i >= 0; i--) SpawningPoint[i + 1] = SpawningPoint[i];
        SpawningPoint[0] = temp;
        loadNewLayer();
    }


    
}



[System.Serializable]
public class SpawningPattern
{
    public float delayToNextPattern;
    public List<NoteToSpawn> AllNote = new List<NoteToSpawn>();
}

[System.Serializable]
public class NoteToSpawn
{
    public notetype typeofNote;
    public bool IsHaveNote;
    public int LayerToSpawn;
}








