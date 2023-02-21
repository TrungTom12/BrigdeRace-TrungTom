using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] private BoxCollider border;
    [SerializeField] private Brick BrickPrefab;
    public List<Brick> listBrick;

    private void Start()
    {
        CreateBrick();

        DefineTypeBrick(Brick.BrickType.Blue);
        DefineTypeBrick(Brick.BrickType.Green);
        DefineTypeBrick(Brick.BrickType.Pink);
        DefineTypeBrick(Brick.BrickType.Red);
    }

    private void CreateBrick()
    {
        for (int i = (int)border.bounds.min.x; i < (int)border.bounds.max.x; i++)
        {
            for (int j = (int)border.bounds.min.z; j < (int)border.bounds.max.z; j++)
            {
                Vector3 pos = new Vector3(i * 2, 0, j * 2);
                Brick Brick = Instantiate(BrickPrefab, pos, Quaternion.identity, transform);
                Brick.type = Brick.BrickType.None;
                listBrick.Add(Brick);
            }
        }
    }

    private void DefineTypeBrick(Brick.BrickType type)
    {
        for (int i = 0; i < 25; i++)
        {
            int ranbdomIndex = Random.Range(0, listBrick.Count);
            Brick Brick = listBrick[ranbdomIndex];
            Brick.type = type;
            listBrick.Remove(Brick);
        }
    }

    //public IEnumerator SpawnBrickRandom(Brick Brick)
    //{
    //    yield return new WaitForSeconds(Random.Range(3, 8));
    //    int randomType = Random.Range(1, 4);
    //    Brick.type = (Brick.BrickType)randomType;
    //    Brick.OnInit();
    //    Brick.gameObject.SetActive(true);
    //}
}