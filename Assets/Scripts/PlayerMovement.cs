using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;

    public List<Transform> _segments;
    public Transform Prefab;
    public GameManager gm;

    private void Start()
    {
        _segments = new List<Transform>();
        _segments.Add(this.transform);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _direction = Vector2.up;
            
        }else if (Input.GetKeyDown(KeyCode.S))
        {
            _direction = Vector2.down;
        }else if (Input.GetKeyDown(KeyCode.A))
        {
            _direction = Vector2.left;
        }else if (Input.GetKeyDown(KeyCode.D))
        {
            _direction = Vector2.right;
        }
   
       
    }

    private void FixedUpdate()
    {

        for(int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }

        this.transform.position = new Vector3(
            (int)(this.transform.position.x) + _direction.x,
            (int)(this.transform.position.y) + _direction.y,
            0.0f);
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


        if (collision.CompareTag("Wall") || 
            collision.CompareTag("PlayerSegment") ||
            collision.CompareTag("OponentSegment"))
        {
            Debug.Log("Chocaste");
            gm.GameOver();
            gm.ResetGame();
        }
    }

    public void ResetGame()
    {
        for (int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }

        _segments.Clear();
        _segments.Add(this.transform);
        this.transform.position = Vector3.zero;
    }
}
