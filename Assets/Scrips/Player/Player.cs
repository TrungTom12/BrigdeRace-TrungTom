using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private int numberBlockOwner;
    public int NumberBlockOwner { get { return numberBlockOwner; } set { numberBlockOwner = value; } }
    public bool IsOnBridge { get; set; }

    [SerializeField] Brick blockBluePrefab;
    public Transform liftingPoint;
    [SerializeField] Stack<Brick> stackBlockBlue = new Stack<Brick>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Brick"))
        {
            Brick block = other.GetComponent<Brick>();
            if (block.type == Brick.BrickType.Blue)
            {
                block.gameObject.SetActive(false);

                numberBlockOwner++;
                Brick blockBluePrefab = Instantiate(this.blockBluePrefab, liftingPoint);
                stackBlockBlue.Push(blockBluePrefab);
                blockBluePrefab.transform.localRotation = liftingPoint.transform.localRotation;
                blockBluePrefab.transform.localPosition = new Vector3(0, numberBlockOwner * 0.1f, -0.8f);
            }
        }
    }


}
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Brick")
    //    {
    //        Brick brick = other.GetComponent<Brick>();
    //        if (brick.type == Brick.BrickType.Red)
    //        {
    //            brick.gameObject.SetActive(false);

    //        }
    //        Destroy(other.gameObject);
    //    }
    //}
