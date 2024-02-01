using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public float newPositionThreshold = 0.2f;
    public float pointArrivalThreshold = 0.05f;
    public Vector2 currentPosition;

    public Sprite[] sprites;
    public AnimationCurve landing;
    public List<Vector2> points;

    private float speed;
    private float landingTimer;
    private Vector2 lastPosition;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb2d;
    private LineRenderer lineRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        rb2d = GetComponent<Rigidbody2D>();

        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);

        transform.position = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0);
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(-180f, 180f));
        speed = Random.Range(1f, 3f);
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length - 1)];
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            landingTimer += 0.5f * Time.deltaTime;
            float interpolation = landing.Evaluate(landingTimer);
            if(transform.localScale.x < 0.1f)
            {
                Destroy(gameObject);
            }
            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, interpolation);
        }

        lineRenderer.SetPosition(0, transform.position);
        if(points.Count > 0)
        {
            if(Vector2.Distance(currentPosition, points[0]) < pointArrivalThreshold)
            {
                points.RemoveAt(0);

                for(int i = 0; i < lineRenderer.positionCount - 1; i++)
                {
                    lineRenderer.SetPosition(i, lineRenderer.GetPosition(i + 1));
                }
                lineRenderer.positionCount--;
            }
        }
    }

    private void FixedUpdate()
    {
        currentPosition = transform.position;
        if(points.Count > 0 )
        {
            Vector2 direction = points[0] - currentPosition;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            rb2d.rotation = -angle;
        }
        rb2d.MovePosition(currentPosition + (Vector2)transform.up * speed * Time.deltaTime);
    }

    private void OnMouseDown()
    {
        points = new List<Vector2>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }

    private void OnMouseDrag()
    {
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(Vector2.Distance(lastPosition, newPosition) > newPositionThreshold)
        {
            points.Add(newPosition);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, newPosition);
            lastPosition = newPosition;
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
