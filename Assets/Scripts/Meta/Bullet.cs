using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool flip;

    private void Awake()
    {
        //Set the rigidbody
        rb = GetComponent<Rigidbody2D>();

        //Rotate the bullet towards the mouse
        Vector2 mousePos = Input.mousePosition;
        Vector2 objectPos = Camera.main.WorldToScreenPoint(rb.position);

        if (mousePos.x < objectPos.x) flip = true;

        float x = mousePos.x - objectPos.x; float y = mousePos.y - objectPos.y;
        float angle = Mathf.Atan(y / x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        //Check if the bullet is out of bounds every second
        InvokeRepeating("CheckDistance", 1f, 1f);
    }

    private void CheckDistance()
    {
        if (Vector3.Distance(GameHandler.Instance.player.transform.position, transform.position) > 100f) Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        //Move the bullet towards the angle it is rotated in
        rb.MovePosition(rb.position + ((Vector2) transform.right * GameHandler.Instance.bulletSpeed * Time.fixedDeltaTime * (flip ? -1 : 1)));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

    }
}
