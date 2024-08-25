using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public float minDirection = 0.5f;
    public float speed;
    public float changePerSecond = 0.2f;

    private Vector3 direction;
    private Rigidbody rb;

    private bool stopped = true;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() 
    {
        if(this.stopped)
            return;
        this.rb.MovePosition(this.rb.position+ direction * speed * Time.fixedDeltaTime);
                speed += changePerSecond * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Wall"))
        {
            direction.z = -direction.z;
        }

        if(other.CompareTag("Racket"))
        {
            Vector3 newDirection = (transform.position - other.transform.position).normalized;
            newDirection.x = Mathf.Sign(newDirection.x) * Mathf.Max(Mathf.Abs(newDirection.x), this.minDirection);
            newDirection.z = Mathf.Sign(newDirection.z) * Mathf.Max(Mathf.Abs(newDirection.z), this.minDirection);

            direction = newDirection;
        }
    }

    public void Stop() {
        stopped = true;
    }

    public void Go() {
        ChooseDirection();
        stopped = false;
    }

    private void ChooseDirection()
    {
        float signX = Mathf.Sign(Random.Range(-1f, 1f));
        float signZ = Mathf.Sign(Random.Range(-1f, 1f));
        this.direction = new Vector3(0.5f * signX, 0, 0.5f * signZ);
    }

}
