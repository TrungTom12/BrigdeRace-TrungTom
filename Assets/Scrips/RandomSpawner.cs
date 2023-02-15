using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] private BoxCollider border;
    [SerializeField] private Brick brickPrefab;
    private List<Brick> listBrick;

    void Start()
    {
        CreateBrick();

        CreateBrick.
    }

    public GameObject cubePrefab;

    // Update is called once per frame

    private void CreateBrick ()
    {
        for (int i = (int)border.bounds.min.x; i < (int)border.bounds.max.z; i++ )
        {
            for (int j = (int)border.bounds.min.x; j < (int)border.bounds.max.z; j++ )
            {
                Vector3 pos = new Vector3(i,0,j);
                Brick brick = Instantiate(brickPrefab, pos, Quaternion.identity, transform);
                brick.type = Brick.BrickType.None;
                listBrick.Add(brick);
            }
        }
    }

    private void DefineTypeBrick(Brick.BrickType type)
    {
        for (int i = 0; i < 25; i++)
        {
            int randomIndex = Random.Range(0, listBrick.Count);
            Brick brick = listBrick[randomIndex];
            brick.type = type;
            listBrick.Remove(brick);
        }
    }


    //void Update()
    //{
    //    Vector3 randomSpawnPosition = new Vector3(Random.Range(-30,-10), 9, Random.Range(40,0));
    //    Instantiate(cubePrefab, randomSpawnPosition, Quaternion.identity);
    //}
}
