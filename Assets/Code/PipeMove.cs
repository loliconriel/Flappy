using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour
{
    [SerializeField]
    private float Speed = 30f;
    // Update is called once per frame
    void Update()
    {
        this.transform.localPosition -= new Vector3(Speed * Time.deltaTime, 0);
        if (transform.position.x < -35) Destroy(gameObject);
    }
}
