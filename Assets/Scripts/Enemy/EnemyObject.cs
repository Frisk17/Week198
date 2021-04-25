using UnityEngine;
using DG.Tweening;
using System.Collections;

public abstract class EnemyObject : MonoBehaviour
{
    public Enemy enemy;

    protected bool dying;

    private SpriteRenderer spriteRenderer;
    private float health;

    public float Health
    {
        get => health;
        set
        {
            //Kill the enemy if the health is 0 or negative
            if (value <= 0f) Die();
            //Do a damage animation if health is lost
            else if (value < health)
            {
                spriteRenderer.DOColor(Color.red, 0.25f);
                StartCoroutine(RestoreColor());
            }
            health = value; 
        }
    }

    /// <summary>
    /// Restores the color.
    /// </summary>
    /// <returns>The color.</returns>
    private IEnumerator RestoreColor()
    {
        yield return new WaitForSeconds(0.25f);
        spriteRenderer.DOColor(enemy.color, 0.25f);
    }

    protected virtual void Die()
    {
        dying = true;
        spriteRenderer.DOColor(Color.red, 0.25f);
        spriteRenderer.DOFade(0f, 0.25f);
        Destroy(gameObject, 0.25f);
    }

    protected virtual void Awake()
    {
        Health = enemy.maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = enemy.sprite;
        spriteRenderer.color = enemy.color;
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        //Reduces health when hit with a bullet
        if (!dying && other.CompareTag("Bullet")) Health -= GameHandler.Instance.bulletDamage;
    }
}
