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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public IEnumerator Start()
    {
        if (SpawnObject == null || SpawnLocationObject == null)
        {
            Debug.LogError("Assign SpawnObject and SpawnLocationObject in Inspector.");
            yield break;
        }
        while (ManaIsFlowing)
        {
            Vector3 startPosition = SpawnLocationObject.transform.position;
            for (int i = 0; i < SpawnCount; i++)
            {
                Vector3 spawnPosition = startPosition + (Random.insideUnitSphere * SpawnScatterRadius);
                Instantiate(SpawnObject, spawnPosition, Quaternion.identity);    
            }
            
            float waitTime = Mathf.Max(0.1f, SpawnRateSeconds); // Limits spawn rate to 1 frame (prevent crashing)
            yield return new WaitForSeconds(waitTime);
        } 
    }
}
