using UnityEngine;
using System.Collections;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public bool ManaIsFlowing = true;
    public int SpawnCount = 3; // How many objects spawn
    public float SpawnRateSeconds = 1.0f; // Rate of which they spawn
    public GameObject SpawnObject; // Object to spawn
    public GameObject SpawnLocationObject; // GameObject to match for spawn point location
    public float SpawnScatterRadius = 0.5f; // Prevents object overlap at spawn point

    private float waitTime = 0;


    void OnEnable()
    {
        toggle_mana.OnManaFlowClicked += toggleManaFlow;
        select_object_for_mana.OnManaTypeSelect += switchManaObject;
    }

    public void Update()
    {
        waitTime += Time.deltaTime;
        if (waitTime >= SpawnRateSeconds && ManaIsFlowing)
        {
            Vector2 startPosition = SpawnLocationObject.transform.position;
            for (int i = 0; i < SpawnCount; i++)
            {
                Vector2 spawnPosition = startPosition + (Random.insideUnitCircle * SpawnScatterRadius);
                Instantiate(SpawnObject, spawnPosition, Quaternion.identity);
            }
            waitTime = 0f;
        }
    }

    void toggleManaFlow(bool state)
    {
        ManaIsFlowing = state;
    }

    void switchManaObject(GameObject obj)
    {
        SpawnObject = obj;
    }
}
