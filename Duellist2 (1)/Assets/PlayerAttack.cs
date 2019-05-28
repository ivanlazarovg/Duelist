using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public Camera cam;
    public GameObject hand;
    public weapon myWeapon;

    private float attackTimer;

    void Start()
    {
        myWeapon = hand.GetComponentInChildren<weapon>();

    }

    void Update()
    {
        attackTimer += Time.deltaTime;
        if (Input.GetMouseButtonUp(0) && attackTimer >= myWeapon.attackCooldown)
        {
            attackTimer = 0f;
            Attack();
        }
    }

    private void Attack()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, myWeapon.attackRange))
        {
            if(hit.collider.tag == "enemy")
            {
                enemyhealth health = hit.collider.GetComponent<enemyhealth>();
                health.takeDamage(myWeapon.attackDamage);
            }
        }
    }
}
