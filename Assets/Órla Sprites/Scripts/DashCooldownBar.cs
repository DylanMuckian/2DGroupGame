using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class DashCoolDownBar : MonoBehaviour
{
    public Image barImage;
    private Mana mana;

    private bool canMana = false;


    private void Awake()
    {
        barImage = transform.Find("Bar").GetComponent<Image>();
        mana = new Mana();


    }

    private void Update()
    {
        mana.Update();
        barImage.fillAmount = mana.GetManaNormalized();

        if (Input.GetKey(KeyCode.Space))
            {
            //Debug.Log("Used Mana");
                canMana = true;
                mana.TrySpendMana(30);
            StartCoroutine(Cooldown());
            }

          
    }

    public class Mana
    {
        public const int manaMax = 100;
        private float manaAmount;
        private float manaRegenAmount;



        public Mana()
        {
            manaAmount = 0;
            manaRegenAmount = 30f;
        }

        public void Update()
        {
            manaAmount += manaRegenAmount * Time.deltaTime;
            manaAmount = Mathf.Clamp(manaAmount, 0f, manaMax);
        }

        public void TrySpendMana(int amount)
        {
            if (manaAmount >= amount)
            {
                manaAmount -= amount;
            }

        }

        public float GetManaNormalized()
        {
            return manaAmount / manaMax;
        }
    }

    private IEnumerator Cooldown() 
    {
        canMana = false;
        yield return new WaitForSeconds(3);

    }
}
