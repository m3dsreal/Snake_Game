using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodRandom : MonoBehaviour
{
    public BoxCollider2D GridArea;
    float XPositionSpawn;
    float YPositionSpawn;
    public GameManager gm;

    // Start is called before the first frame update
    private void Awake()
    {
        RandomPosition();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void RandomPosition()
    {
        Bounds bounds = this.GridArea.bounds;
        XPositionSpawn = Random.Range(bounds.min.x, bounds.max.x);
        YPositionSpawn = Random.Range(bounds.min.y, bounds.max.y);
        this.transform.position = new Vector3((int)XPositionSpawn, (int)YPositionSpawn, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            RandomPosition();
            gm.UpdateScorePlayer(10);
        }

        if (collision.CompareTag("Oponent"))
        {
            RandomPosition();
            gm.UpdateScoreOponent(10);
        }
    }
}
