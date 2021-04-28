using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShoot : MonoBehaviour
{
	public GameObject bullet;

	public int activatedStage;
	// optimization

	[Header("Turret Properties")]
	public float firstShotDelay;
	public float shotCool;
	public float shotSpeed;

	[Header("Set Shooting Direction")]
	[SerializeField]
	bool toUp = false;
	[SerializeField]
	bool toRight = false;
	[SerializeField]
	bool toDown = false;
	[SerializeField]
	bool toLeft = false;

	Ball playerBall;
	SpriteRenderer sr;
	float shotTimer;

	// Start is called before the first frame update
	void Start()
	{
		shotTimer = -firstShotDelay;

		playerBall = FindObjectOfType<Ball>();
		sr = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update()
	{
		if(playerBall.CurStage == activatedStage)
		{
			shotTimer += Time.deltaTime;
			if (shotTimer >= shotCool)
			{
				Shoot();
				shotTimer = 0f;
			}
		}

		sr.color = 
			Color.Lerp(new Color(1f, 1f, 1f, 1f), new Color(0.5f, 0.5f, 0.5f, 1f), shotTimer / shotCool);
	}

	void Shoot()
	{
		if (toUp)
		{
			GameObject shoot = 
				Instantiate(bullet, transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);

			Bullet shootBullet = shoot.GetComponent<Bullet>();

			shootBullet.TowardUp = true;
			shootBullet.Speed = shotSpeed;
		}

		if (toRight)
		{
			GameObject shoot =
				Instantiate(bullet, transform.position + new Vector3(1f, 0f, 0f), Quaternion.identity);

			Bullet shootBullet = shoot.GetComponent<Bullet>();

			shootBullet.TowardRight = true;
			shootBullet.Speed = shotSpeed;
		}

		if (toDown)
		{
			GameObject shoot =
				Instantiate(bullet, transform.position - new Vector3(0f, 1f, 0f), Quaternion.identity);

			Bullet shootBullet = shoot.GetComponent<Bullet>();

			shootBullet.TowardDown = true;
			shootBullet.Speed = shotSpeed;
		}

		if (toLeft)
		{
			GameObject shoot =
				Instantiate(bullet, transform.position - new Vector3(1f, 0f, 0f), Quaternion.identity);

			Bullet shootBullet = shoot.GetComponent<Bullet>();

			shootBullet.TowardLeft = true;
			shootBullet.Speed = shotSpeed;
		}
	}
}
