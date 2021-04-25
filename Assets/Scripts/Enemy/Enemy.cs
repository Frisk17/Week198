using UnityEngine;

/// <summary>
/// Enemy ScriptableObject
/// </summary>
[CreateAssetMenu(fileName = "Enemy", menuName = "Data/Enemy")]
public class Enemy : ScriptableObject
{
    public new string name;
    public Sprite sprite;
    public Color color = Color.white;
    public float maxHealth;
}
