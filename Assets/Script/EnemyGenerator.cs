using System.Collections;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab;
    Vector2 spawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = new Vector2();
        StartCoroutine(Generate());
    }

    IEnumerator Generate()
    {
        //Assignmet 04 Start
        if (LevelManager.instance.isGameOver || LevelManager.instance.isGameWon)
            yield return new WaitForEndOfFrame();
        //Assignmet 04 End

        else
        {
            spawnPosition = new Vector2(Random.Range(-7f, 7f), transform.position.y);
            yield return new WaitForSeconds(0.5f);
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(Random.Range(0.5f, 2f));
            StartCoroutine(Generate());
        }
    }
}

