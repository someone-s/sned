using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] slots;
    [SerializeField] private Transform spawn;
    private LinkedList<GameObject> items = new();

    [SerializeField] private SpawnSpec[] spawnSpecs;
    private float totalFrequency;

    [Serializable]
    private class SpawnSpec
    {
        public GameObject prefab;
        [Min(0f)]
        public float frequency;
    }

    private void Awake()
    {
        totalFrequency = spawnSpecs.Sum(spec => spec.frequency);
    }

    private void Start()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            Spawn();
            GameObject item = items.Last();
            item.GetComponent<SmoothMove>().Position = slots[i].localPosition;
            item.GetComponent<SmoothScale>().Scale = slots[i].localScale;
        }
    }

    private void Spawn()
    {
        float random = UnityEngine.Random.Range(0f, totalFrequency);
        float combine = 0f;
        for (int i = 0; i < spawnSpecs.Length; i++)
        {
            combine += spawnSpecs[i].frequency;
            if (combine >= random)
            {
                GameObject item = Instantiate(spawnSpecs[i].prefab);
                Transform slot = slots[slots.Length - 1];
                item.GetComponent<SmoothMove>().Position = spawn.localPosition;
                item.GetComponent<SmoothScale>().Scale = spawn.localScale;
                items.AddLast(item);
                break;
            }
        }
    }

    [Button]
    public GameObject Take()
    {
        GameObject output = items.First();

        items.RemoveFirst();

        Spawn();

        int i = 0;
        foreach (GameObject item in items)
        {
            item.GetComponent<SmoothMove>().TargetPosition = slots[i].localPosition;
            item.GetComponent<SmoothScale>().TargetScale = slots[i].localScale;
            i++;
        }

        return output;
    }
}
