using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Sirenix.OdinInspector;
using UnityEngine;

public class ItemSpawner : SerializedMonoBehaviour
{
    [SerializeField] private Transform[] queueSlots;
    [SerializeField] private Transform spawnSlot;
    [SerializeField] private Transform slotParent;
    private LinkedList<GameObject> queueItems = new();

    [SerializeField] private Dictionary<AccesorySpawnType, AccesorySpawnGroup> accesorySpawnGroups;

    [Serializable]
    private class AccesorySpawnGroup
    {
        public AccesorySpawnSpec[] specs;
        public float allowed;
    }

    private enum AccesorySpawnType
    {
        Large,
        Medium,
        Small
    }

    [Serializable]
    private class AccesorySpawnSpec
    {
        public GameObject prefab;
        public float weight;
    }

    [SerializeField] private StorageSpawnSpec[] storageSpawnSpecs;

    [Serializable]
    private class StorageSpawnSpec
    {
        public GameObject prefab;
        public float weight;
        public AccesorySpawnType[] contributions;
    }

    private void Start()
    {
        for (int i = 0; i < queueSlots.Length; i++)
        {
            Spawn();
            GameObject item = queueItems.Last();
            item.GetComponent<SmoothMove>().Position = queueSlots[i].localPosition;
            item.GetComponent<SmoothScale>().Scale = queueSlots[i].localScale;
        }
    }

    private void Spawn()
    {
        if (accesorySpawnGroups.Sum(group => group.Value.allowed) <= 0)
        {
            SpawnStorage();
        }
        else
        {
            SpawnAccesory();
        }
    }

    private void SpawnStorage()
    {
        float random = UnityEngine.Random.Range(0f, storageSpawnSpecs.Sum(spec => spec.weight));
        float combine = 0f;
        for (int i = 0; i < storageSpawnSpecs.Length; i++)
        {
            combine += storageSpawnSpecs[i].weight;
            if (combine >= random)
            {
                GameObject item = Instantiate(storageSpawnSpecs[i].prefab, slotParent);
                item.GetComponent<SmoothMove>().Position = spawnSlot.localPosition;
                item.GetComponent<SmoothScale>().Scale = spawnSlot.localScale;
                queueItems.AddLast(item);
                foreach (AccesorySpawnType contribution in storageSpawnSpecs[i].contributions)
                    accesorySpawnGroups[contribution].allowed++;
                break;
            }
        }
    }

    private void SpawnAccesory()
    {
        float random = UnityEngine.Random.Range(0f, accesorySpawnGroups.Sum(group => group.Value.allowed));
        float combine = 0f;
        foreach (KeyValuePair<AccesorySpawnType, AccesorySpawnGroup> pair in accesorySpawnGroups)
        {
            combine += pair.Value.allowed;
            if (combine >= random)
            {
                float random2 = UnityEngine.Random.Range(0f, pair.Value.specs.Sum(spec => spec.weight));
                float combine2 = 0f;
                for (int i = 0; i < pair.Value.specs.Length; i++)
                {
                    combine2 += pair.Value.specs[i].weight;
                    if (combine2 >= random2)
                    {
                        GameObject item = Instantiate(pair.Value.specs[i].prefab, slotParent);
                        item.GetComponent<SmoothMove>().Position = spawnSlot.localPosition;
                        item.GetComponent<SmoothScale>().Scale = spawnSlot.localScale;
                        queueItems.AddLast(item);
                        pair.Value.allowed--;
                        break;
                    }
                }
                break;
            }
        }
    }

    public GameObject First => queueItems.First();

    [Button]
    public void Shift()
    {
        Debug.Log(queueItems.Count);
        queueItems.RemoveFirst();

        Spawn();
        Debug.Log(queueItems.Count);

        int i = 0;
        foreach (GameObject item in queueItems)
        {
            item.GetComponent<SmoothMove>().TargetPosition = queueSlots[i].localPosition;
            item.GetComponent<SmoothScale>().TargetScale = queueSlots[i].localScale;
            i++;
        }
    }
}
