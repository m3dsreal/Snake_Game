using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oponents : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;
    bool flag = true;
    public Transform Food;
    Vector3 FoodTarget;

    public List<Transform> _segments;
    public Transform Prefab;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        Target();
        _segments = new List<Transform>();
        _segments.Add(this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        Target();
    }

    private void FixedUpdate()
    {
        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }


        movementOponent();



        if (this.transform.position.x == FoodTarget.x)
        {
            flag = false;
            Debug.Log("horizontal");
            //movementOponent();
        }

        if (this.transform.position.y == FoodTarget.y)
        {
            flag = true;
            Debug.Log("vertical");
            //movementOponent();
        }
    }

    void Target()
    {
        FoodTarget = new Vector3(Food.position.x, Food.position.y, 0f);
    }


    void movementOponent()
    {
        if (FoodTarget.x > 0 && this.transform.position.x < FoodTarget.x && flag == true)
        {
            _direction = Vector2.right;
            this.transform.position = new Vector3((int)(this.transform.position.x) + _direction.x, (int)this.transform.position.y, 0f);
        }

        if (FoodTarget.x > 0 && this.transform.position.x > FoodTarget.x && flag == true)
        {
            _direction = Vector2.left;
            this.transform.position = new Vector3((int)(this.transform.position.x) + _direction.x, (int)this.transform.position.y, 0f);
        }

        if (FoodTarget.x < 0 && this.transform.position.x < FoodTarget.x && flag == true)
        {
            _direction = Vector2.right;
            this.transform.position = new Vector3((int)(this.transform.position.x) + _direction.x, (int)this.transform.position.y, 0f);
        }

        if (FoodTarget.x < 0 && this.transform.position.x > FoodTarget.x && flag == true)
        {
            _direction = Vector2.left;
            this.transform.position = new Vector3((int)(this.transform.position.x) + _direction.x, (int)this.transform.position.y, 0f);
        }




        if (FoodTarget.y > 0 && this.transform.position.y < FoodTarget.y && flag == false)
        {
            _direction = Vector2.up;
            this.transform.position = new Vector3((int)(this.transform.position.x), (int)this.transform.position.y + _direction.y, 0f);
        }

        if (FoodTarget.y > 0 && this.transform.position.y > FoodTarget.y && flag == false)
        {
            _direction = Vector2.down;
            this.transform.position = new Vector3((int)(this.transform.position.x), (int)this.transform.position.y + _direction.y, 0f);
        }

        if (FoodTarget.y < 0 && this.transform.position.y < FoodTarget.y && flag == false)
        {
            _direction = Vector2.up;
            this.transform.position = new Vector3((int)(this.transform.position.x), (int)this.transform.position.y + _direction.y, 0f);
        }

        if (FoodTarget.y < 0 && this.transform.position.y > FoodTarget.y && flag == false)
        {
            _direction = Vector2.down;
            this.transform.position = new Vector3((int)(this.transform.position.x), (int)this.transform.position.y + _direction.y, 0f);
        }
    }

    private void Grow()
    {
        Transform segment = Instantiate(this.Prefab);
        segment.position = _segments[_segments.Count - 1].position;



        _segments.Add(segment);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
        {
            Grow();
        }

        if (collision.CompareTag("PlayerSegment"))
        {
            Debug.Log("Chocaste con el player");
            gm.GameOver();
            gm.ResetGame();
        }

    }
}
