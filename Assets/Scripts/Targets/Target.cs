using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] float health = 10f;
    private TargetCounter targetCounter;

    public void Initialize(TargetCounter counter)
    {
        targetCounter = counter;
    }

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
        // Notify the TargetCounter
        if (targetCounter != null)
        {
            targetCounter.TargetDestroyed();
        }

        Destroy(gameObject);
    }
}
