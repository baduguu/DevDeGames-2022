using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(enemyWave());
    }
    
    private void spawnEnemy(){
        GameObject enem = Instantiate(enemyPrefab) as GameObject;
        enem.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y* 2);
    }

    IEnumerator enemyWave(){
        while(true){
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();    
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
