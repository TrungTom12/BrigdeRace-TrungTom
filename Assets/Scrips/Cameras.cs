using System.Collections.Generic;
using UnityEngine;

public class follow_mainship : MonoBehaviour
{
    public Transform Playerposition;
    private Vector3 cameraoffset;
    // Start is called before the first frame update
    void Start()
    {
        cameraoffset = Playerposition.position - transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newpos = Playerposition.position + cameraoffset;
    }
}