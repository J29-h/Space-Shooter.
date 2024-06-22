using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    float speed = 6f;


    // Update is called once per frame
    public void Update()
    {
        transform.Translate(transform.up * speed * Time.deltaTime);
    }
}
