using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class FruitSpawner : MonoBehaviour {

	public List<GameObject> prefabs;

	public float minDelay = .1f;
	public float maxDelay = 1f;

	void Start () 
	{
		StartCoroutine(SpawnFruits());
	}

    private void Update()
    {
        if (!GameManager.Instance.gameIsActive)
            StopAllCoroutines();
    }

    IEnumerator SpawnFruits ()
	{
		while (true)
		{
			float delay = Random.Range(minDelay, maxDelay);
			yield return new WaitForSeconds(delay);

			int spawnIndex = Random.Range(0, prefabs.Count);

			Instantiate(prefabs[spawnIndex], new Vector2(Random.Range(-7, 7), transform.position.y), transform.rotation);
		}
	}

    private void OnTriggerExit(Collider other)
    {
		if (other.CompareTag("Destroyable"))
		{
			Destroy(other.gameObject);
		}
    }

}
