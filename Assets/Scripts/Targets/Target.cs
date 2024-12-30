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


// using UnityEngine;

// public class Target : MonoBehaviour
// {
//     [SerializeField] private float health = 10f;
//     private TargetCounter targetCounter;
//     private GameManagerTimer gameManagerTimer; // Reference to the GameManagerTimer

//     public void Initialize(TargetCounter counter, GameManagerTimer managerTimer)
//     {
//         targetCounter = counter;
//         gameManagerTimer = managerTimer; // Initialize the reference to GameManagerTimer
//     }

//     public void TakeDamage(float amount)
//     {
//         health -= amount;
//         if (health <= 0)
//         {
//             Die();
//         }
//     }

//     private void Die()
//     {
//         // Notify the GameManagerTimer that a target was destroyed
//         if (gameManagerTimer != null)
//         {
//             gameManagerTimer.TargetDestroyed(); // Increment the destroyed target count
//         }

//         // Notify the TargetCounter
//         if (targetCounter != null)
//         {
//             targetCounter.TargetDestroyed();
//         }

//         Destroy(gameObject);
//     }
// }
