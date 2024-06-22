using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetoorControl : MonoBehaviour
{
    float speed;
    public GameObject MeteoreExplosion;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(1.5f, 2.5f);
        GetComponent<Rigidbody2D>().velocity = transform.up * -1 * speed;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Instantiate(MeteoreExplosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject, 0.05f);
            AudioManager.instance.OnExplode(0);
            ScoreManager.instance.AddScore(1);
        }
    }
}
