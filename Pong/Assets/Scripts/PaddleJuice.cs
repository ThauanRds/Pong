using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PaddleJuice : MonoBehaviour
{
    public Transform paddleSprite;
    public float bounceForce;

    public void PlayHitEffect()
    {
        paddleSprite.transform.DOScale(1.3f, 0.1f).SetLoops(2, LoopType.Yoyo);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            // Armazenando o rigidbody da bola
            Rigidbody2D ballRig = collision.gameObject.GetComponent<Rigidbody2D>();
            // Calculando a posição do impacto no eixo y
            float yOffset = collision.transform.position.y - transform.position.y;
            // Armazenando o tamanho do paddle
            float paddleHeight = GetComponent<Collider2D>().bounds.size.y;
            // Transformando a posição do impacto em um valor
            float normalizedY = yOffset / (paddleHeight / 2f); // -1 (se bater embaixo), 0 (se bater no meio), 1 (se bater em cima)

            // Armazenando a nova direção da bola
            Vector2 direction = new Vector2(Mathf.Sign(ballRig.velocity.x), normalizedY).normalized;

            // Aplicando a nova direção e a força de impulso
            ballRig.velocity = direction * bounceForce;
        }
    }
}
