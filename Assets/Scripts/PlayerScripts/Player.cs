using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
        public int HP = 100;
        public GameObject bloodyScreen;

        public TextMeshProUGUI playerHealthUI;

    void Start()
    {
        playerHealthUI.text = $"Health: {HP}";
    }





        public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;

        if (HP <= 0)
        {
            PlayerDead();
        }
        else
        {
            StartCoroutine(BloodyScreenEffect());
            playerHealthUI.text = $"Health:{HP}";
        }
    }


    public void PlayerDead()
    {
        SceneManager.LoadScene("GameOver");
        playerHealthUI.gameObject.SetActive(false);
    }


    private IEnumerator BloodyScreenEffect()
    {
        if (bloodyScreen.activeInHierarchy == false)
        {
            bloodyScreen.SetActive(true);
        }

        yield return new WaitForSeconds(2f);

        if (bloodyScreen.activeInHierarchy)
        {
            bloodyScreen.SetActive(false);
        }
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ZombieHand"))
        {
            Debug.Log("Zombie hand entered");
            TakeDamage(25);
        }
    }
}
