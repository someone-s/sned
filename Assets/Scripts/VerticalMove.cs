using System;
using UnityEngine;

public class VerticalMove : MonoBehaviour
{
    public float speed;

    [SerializeField] private SmoothMove smoothMove;
    [SerializeField] private SpawnSpec[] spawnSpecs;

    [Serializable]
    private class SpawnSpec
    {
        public GameObject prefab;
        public float prefabHeight;
        public float startHeight;
        public float elapsedHeight;
    }

    public void Move(float y)
    {
        smoothMove.TargetPosition += new Vector3(0f, y, 0f);

        for (int i = 0; i < spawnSpecs.Length; i++)
        {
            spawnSpecs[i].elapsedHeight += y;
            if (spawnSpecs[i].elapsedHeight > spawnSpecs[i].prefabHeight)
            {
                spawnSpecs[i].elapsedHeight -= spawnSpecs[i].prefabHeight;
                GameObject spawnObject = Instantiate(spawnSpecs[i].prefab);
                spawnObject.transform.position += new Vector3(0f, spawnSpecs[i].startHeight, 0f);
                spawnSpecs[i].startHeight += spawnSpecs[i].prefabHeight;
            }
        }
    }
}