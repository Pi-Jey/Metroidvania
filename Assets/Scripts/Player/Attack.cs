using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
	public float dmgValue = 4;
	public GameObject bullet;
	public Transform attackCheck;
	private Rigidbody2D m_Rigidbody2D;
	public Animator animator;
	public bool canAttack = true;
    public bool canShoot = true;
    public bool isTimeToCheck = false;
	private bool AbleToShoot = false;

	public GameObject cam;

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}
	public void GettingAbleToShoot()
	{
		AbleToShoot=true;
	}

    void Update()
    {
		if (Input.GetKeyDown(KeyCode.X) && canAttack)
		{
			canAttack = false;
			animator.SetBool("IsAttacking", true);
			StartCoroutine(AttackCooldown());
		}

		if (Input.GetKeyDown(KeyCode.V) && AbleToShoot && canShoot)
		{
			canShoot = false;
            GameObject _bullet = Instantiate(bullet, transform.position + new Vector3(transform.localScale.x * 0.5f,-0.2f), Quaternion.identity) as GameObject;
            _bullet.GetComponent<Bullet>().owner = gameObject;
            _bullet.GetComponent<Bullet>().target = "Enemy";
            Vector2 direction = new Vector2(transform.localScale.x, 0f);
			_bullet.GetComponent<Bullet>().direction = direction; 
			_bullet.name = "PlayerBullet";
            StartCoroutine(ShootingCooldown());
        }
	}

	IEnumerator AttackCooldown()
	{
		yield return new WaitForSeconds(0.25f);
		canAttack = true;
	}
	IEnumerator ShootingCooldown()
	{
		yield return new WaitForSeconds(0.25f);
		canShoot = true;
	}

    public void DoDashDamage()
	{
		dmgValue = Mathf.Abs(dmgValue);
		Collider2D[] collidersEnemies = Physics2D.OverlapCircleAll(attackCheck.position, 0.9f);
		for (int i = 0; i < collidersEnemies.Length; i++)
		{
			if (collidersEnemies[i].gameObject.tag == "Enemy")
			{
				if (collidersEnemies[i].transform.position.x - transform.position.x < 0)
				{
					dmgValue = -dmgValue;
				}
				collidersEnemies[i].gameObject.SendMessage("GetDamage", dmgValue);
				cam.GetComponent<CameraFollow>().ShakeCamera();
			}
		}
	}
}
