using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Create dialogue sequence", menuName = "ScriptableObjects", order = 1)]

public class DialoguesObject : ScriptableObject
{
    
    public string[] Dialogues;
    public GameObject prefab;

}
