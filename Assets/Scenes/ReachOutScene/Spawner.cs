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
    public GameObject topRight;
    public GameObject bottomLeft;
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
            Instantiate(ge, new Vector3(Random.Range(bottomLeft.transform.position.x, topRight.transform.position.x), 
            Random.Range(bottomLeft.transform.position.y, topRight.transform.position.y), transform.position.z), transform.rotation, transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
