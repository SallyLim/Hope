using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ge;
    public float spawnInterval;
    public float spawnIntervalVariance;
    private RectTransform rect;
    private float width;
    private float height;
    void Start()
    {
        StartCoroutine(SpawnGe());
        rect = GetComponent<RectTransform>();
        width = rect.sizeDelta.x;
        height = rect.sizeDelta.y;
    }

    IEnumerator SpawnGe()
    {
        while(true) {
            yield return new WaitForSeconds(spawnInterval + Random.Range(0, spawnIntervalVariance));
            Instantiate(ge, new Vector3(Random.Range(-width / 2, width / 2), Random.Range(-height / 2, height / 2), transform.position.z), transform.rotation, transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
