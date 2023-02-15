using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] private Material blueMesh;
    [SerializeField] private Material greenMesh;
    [SerializeField] private Material redMesh;
    [SerializeField] private Material pinkMesh;
    public enum BrickType
    {
        Blue,
        Green,
        Red,
        Pink,
        None
    }
    public BrickType type;
    // Start is called before the first frame update
    void Start()
    {
        OnInit();
    }

    public void OnInit()
    {
        switch (type)
        {
            case BrickType.Blue:
                GetComponent<MeshRenderer>().material = blueMesh;
                break;
            case BrickType.Red:
                GetComponent<MeshRenderer>().material = redMesh;
                break;
            case BrickType.Green:
                GetComponent<MeshRenderer>().material = greenMesh;
                break;
            case BrickType.Pink:
                GetComponent<MeshRenderer>().material = pinkMesh;
                break;
            default:
                break;
        }
    }
}
   