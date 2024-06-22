using System.Collections;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 7f;
    float Player_direction = 0;
    public float xmin, xmax;
    public GameObject[] bulletPrefab;
    public GameObject ExplodeParticles;
    int BulletAmount = 7;
    int max_Bullet = 7;
    


    public void Start()
    {
        if(LevelManager.instance.current_lives == LevelManager.instance.max_lives)
 
            return;
            GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 80);
            Invoke("RespawnComplete", 5f);
    }

    void RespawnComplete()
    {
        LevelManager.instance.isRespawning = false;
        GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
    }
    // Update is called once per frame
    void Update()
    {
        Player_direction = Input.GetAxisRaw("Horizontal");

        if((Player_direction < 0 && transform.position.x > xmin) || (Player_direction > 0 &&transform.position.x <xmax))
        transform.Translate(Vector2.right * Player_direction * speed *Time.deltaTime);

        // Assignmet 03 Start 
        if (Input.GetKeyDown(KeyCode.Space))
            if(ScoreManager.instance.currentScore >= 50)
            {
                Shoot(1);
            }
            else
            {
                Shoot(0);
            }
        //Assignmet 04 Start
        if (ScoreManager.instance.currentScore == 100)
        {
            LevelManager.instance.GameWonPopUp();
        }
        //Assignmet 04 End
    }
    // Assignmet 02 Start 
    void Shoot(int Index)
    {
        if(BulletAmount != 0)
        {
            Instantiate(bulletPrefab[Index], transform.position, Quaternion.identity);
            AudioManager.instance.OnBulletFired();
            BulletAmount -= 1;
        }

        if(BulletAmount <= 0)
        {
            StartCoroutine(Reload());
        }
    }
    //Assignmet 03 End

    IEnumerator Reload()
    {
        Debug.Log("Reloding...");
        yield return new WaitForSeconds(3f);
        Debug.Log("Reloded");
        BulletAmount = max_Bullet;
    }
    // Assignmet 02 End 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LevelManager.instance.isRespawning)
            return;

        Instantiate(ExplodeParticles, transform.position, Quaternion.identity);
        AudioManager.instance.OnExplode(0);
        LevelManager.instance.current_lives--;
        Destroy(gameObject);
        LevelManager.instance.UpdateLivesText();
        if (LevelManager.instance.current_lives <= 0)
        {
            LevelManager.instance.ShowPopUp();
        } 
        else
        {
            LevelManager.instance.ReSpawnPlayer();
        }
    }
}
