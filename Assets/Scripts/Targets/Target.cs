using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] float health = 50f;
    
    public void TakeDamge(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
