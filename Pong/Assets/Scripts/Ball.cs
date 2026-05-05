using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Ball : MonoBehaviour
{
    public float speed;
    public TrailRenderer trail;

    private Rigidbody2D rb;
    public  SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(PlayBall());
    }

    // Controla o arremesso inicial dabola
    void Launch()
    {
        Vector2 direction = Vector2.zero;

        // Vai para a esquerda
        if(Random.value < 0.5f)
        {
            direction = Vector2.left;
        }
        // Vai para a direita
        else
        {
            direction = Vector2.right; 
        }

        direction.y = Random.Range(-0.5f, 0.5f);

        rb.velocity = direction * speed;
    }

    public void ResetBall()
    {
        rb.velocity = Vector2.zero;
        trail.Clear();
        trail.enabled = false;
        transform.position = Vector2.zero;
        trail.enabled = true; 

        StartCoroutine(PlayBall());
    }

    IEnumerator PlayBall()
    {
        sprite.enabled = true;
        yield return new WaitForSeconds(0.5f);
        sprite.enabled = false;
        yield return new WaitForSeconds(0.5f);
        sprite.enabled = true;
        yield return new WaitForSeconds(0.5f);
        sprite.enabled = false;
        yield return new WaitForSeconds(0.5f);
        sprite.enabled = true;

        Launch();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Paddle")
        {
            other.gameObject.GetComponent<PaddleJuice>().PlayHitEffect();

            BallJuice();
        }


        if(other.gameObject.layer == 6)
        {
            BallJuice();
        }
    }

    void BallJuice()
    {
        sprite.transform.DOScale(1.8f, 0.1f).SetLoops(2, LoopType.Yoyo);

        Camera.main.transform.DOShakePosition(
            0.1f, //Duração
            0.2f, // Força do shake
            10, // Vibrações
            90, // Aleatoriedade
            false, // Não mudar o eixo z
            true // Fade out
            );
    }
}
