using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] private int HP = 100;
    private Animator animator;
    private UnityEngine.AI.NavMeshAgent navAgent;
    private GameManager gameManager;
    private bool isDead = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        gameManager = FindObjectOfType<GameManager>();
    }

    public void TakeDamage(int damageAmount)
    {
        if (isDead) // If the zombie is already dead, exit the method
            return;

        HP -= damageAmount;
        if (HP <= 0)
        {
            isDead = true;
            int randomValue = Random.Range(0, 2);

            if (randomValue == 0)
            {
                animator.SetTrigger("DIE1");
            }
            else
            {
                animator.SetTrigger("DIE2");
            }

            if (gameManager != null)
            {
                gameManager.ZombieKilled(); // Decrease the count of zombies when killed
            }
            SoundManager.Instance.zombieChannel2.PlayOneShot(SoundManager.Instance.zombieDeath);
            StartCoroutine(DestroyAfterDelay(4.5f));
        }
        else
        {
            animator.SetTrigger("DAMAGE");
            SoundManager.Instance.zombieChannel2.PlayOneShot(SoundManager.Instance.zombieHurt);
        }
    }
    private IEnumerator DestroyAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            Destroy(gameObject); // Destroy the zombie GameObject
        }
}