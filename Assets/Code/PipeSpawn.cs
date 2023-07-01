using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PipeSpawn : MonoBehaviour
{
    public GameObject Pipe;
    [SerializeField]
    private float SpawnTime = 2f;
    [SerializeField]
    private float RepeatTime = 4f;
    [SerializeField]
    private float minHeight = -10f;
    [SerializeField]
    private float maxHeight = 10f;
    
    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), SpawnTime, RepeatTime);
    }

    private void Spawn()
    {
        GameObject pipe = Instantiate(Pipe,transform.position,Quaternion.identity);
        pipe.transform.position += new Vector3(0, Random.Range(minHeight, maxHeight)) ;
    }
}
