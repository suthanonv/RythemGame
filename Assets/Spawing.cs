using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawing : MonoBehaviour
{
    [SerializeField] List<SpawningPattern> patterntospawn = new List<SpawningPattern>();
    [SerializeField] GameObject NotePrefab;
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





