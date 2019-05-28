
using UnityEngine;

public class enemyhealth : MonoBehaviour {

    public float Health = 50f;

    public void takeDamage(float amount)
    {
        Health -= amount;
        if(Health <= 0)
        {
            print("And the man is dead!");
            Destroy(gameObject);
        }

        print("took some damage");
    }
}
