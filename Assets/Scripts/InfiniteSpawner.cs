using System.Collections.Generic;
using UnityEngine;

public class InfiniteSpawner : MonoBehaviour
{
    [SerializeField] private float interval;
    private float elapsed = 0f;
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private float aliveDuration;
    [SerializeField] private float spread;

    private Queue<Status> statuses = new();

    private class Status
    {
        public GameObject spawnedObject;
        public float aliveTime;
    }

    private void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= interval)
        {
            elapsed = 0f;
            GameObject newObject = Instantiate(prefabs[Random.Range(0, prefabs.Length - 1)]);

            newObject.GetComponent<SpriteRenderer>().sortingLayerID = SortingLayer.NameToID("Middleground");
            if (newObject.TryGetComponent(out Rigidbody2D rigidbody2D))
            {
                rigidbody2D.constraints = RigidbodyConstraints2D.None;
                rigidbody2D.simulated = true;
            }
            newObject.GetComponent<SmoothMove>().enabled = false;

            newObject.transform.position = transform.position + new Vector3(Random.Range(-spread, spread) , 0f, 0f);
            statuses.Enqueue(new Status()
            {
                spawnedObject = newObject,
                aliveTime = 0f
            });
        }

        foreach (Status status in statuses)
            status.aliveTime += Time.deltaTime;

        while (statuses.Count >= 1 && statuses.Peek().aliveTime > aliveDuration)
            {
                Status status = statuses.Dequeue();
                Destroy(status.spawnedObject);
            }
    }
}
