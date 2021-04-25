using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameHandler : Singleton<GameHandler>
{
    public float playerSpeed;
    public float bulletSpeed;
    public float bulletDamage;

    public GameObject player;

    [SerializeField]
    #pragma warning disable IDE0044 // Add readonly modifier
    private GameObject bulletPrefab;
    #pragma warning restore IDE0044 // Add readonly modifier

    private bool bulletCooldown;

    private const float bulletCooldownTime = 0.25f;

    protected override void Awake()
    {
        destroyOnLoad = false;
        base.Awake();

        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (!bulletCooldown && Input.GetMouseButton(0)) Shoot();
    }

    /// <summary>
    /// Instantiate a bullet
    /// </summary>
    private void Shoot()
    {
        Instantiate(bulletPrefab, player.transform.position, Quaternion.identity);
        bulletCooldown = true;
        StartCoroutine(SetCooldown(false));
    }

    /// <summary>
    /// Sets the cooldown.
    /// </summary>
    /// <returns>The cooldown.</returns>
    /// <param name="value">If set to <c>true</c> value.</param>
    private IEnumerator SetCooldown(bool value)
    {
        yield return new WaitForSeconds(bulletCooldownTime);
        bulletCooldown = value;
    }

    /// <summary>
    /// Called when the scene is loaded.
    /// </summary>
    /// <param name="scene">Scene.</param>
    /// <param name="mode">Mode.</param>
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
}
