using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnSpawner : MonoBehaviour
{
    public GameObject columnPrefab;
    public float spawnTime = 4f;
    public float elapsedTime = 0f;
    public float columnSpeed = 4f;

    private void Update()
    {
        if(!GameController.instance.gameOver)
        {
            if (elapsedTime < spawnTime)
            {
                elapsedTime += Time.deltaTime;
            }
            else
            {
                float random = Random.Range(-2f, 2f);
                Column newCol = Instantiate(columnPrefab, new Vector3(10f, random, 0), Quaternion.identity).
                    GetComponent<Column>();
                newCol.scrollingSpeed = columnSpeed;
                elapsedTime = 0f;
            }
        }
    }
}
