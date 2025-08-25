using System;
using UnityEngine;

public class VerticalMove : MonoBehaviour
{
    public float speed;

    [SerializeField] private SpawnSpec[] spawnSpecs;

    [Serializable]
    private class SpawnSpec
    {
        public GameObject prefab;
        public float prefabHeight;
        public float startHeight;
        public float elapsedHeight;
    }

    private void Update()
    {
        float move = speed * Time.deltaTime;

        transform.position += new Vector3(0f, move, 0f);
        for (int i = 0; i < spawnSpecs.Length; i++)
        {
            spawnSpecs[i].elapsedHeight+= move;
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