using UnityEngine;

/// <summary>
/// Просто перемещает текущий объект игры
/// </summary>
public class Enemy : MonoBehaviour
{
    // 1 - переменные

    /// <summary>
    /// Скорость объекта
    /// </summary>
    public Vector2 speed = new Vector2(10, 10);

    /// <summary>
    /// Направление движения
    /// </summary>
    public Vector2 direction = new Vector2(-1, 0);

    private Vector2 movement;
    private static Vector2 velocity;

    void Update()
    {
        // 2 - Перемещение
        /*movement = new Vector2(
          speed.x * direction.x,
          speed.y * direction.y);
        */
        float speedLocal = 5f;
        transform.Translate(Vector2.left * speedLocal * Time.deltaTime);
    }

    void FixedUpdate()
    {
        // Применить движение к Rigidbody
        Enemy.velocity = movement;
    }
}
