using UnityEngine;

namespace HJ
{
    public class HJ_Enemy : MonoBehaviour, IDamageable
    {
        public float health = 100.0f;
        public void TakeDamage(float damageAmount)
        {
            health -= damageAmount;
            Debug.Log("Enemy health is: " + health);
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}