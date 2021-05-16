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
	public bool toUp;
	public bool toRight;
	public bool toDown;
	public bool toLeft;

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
				ShootUp();
				ShootRight();
				ShootDown();
				ShootLeft();

				shotTimer = 0f;
			}
		}

		sr.color = 
			Color.Lerp(Color.white, Color.gray, shotTimer / shotCool);
	}

	void ShootUp()
	{
		if (toUp)
		{
			GameObject shoot = 
				Instantiate(bullet, transform.position + Vector3.up, Quaternion.identity);

			Bullet shootBullet = shoot.GetComponent<Bullet>();

			shootBullet.TowardUp = true;
			shootBullet.Speed = shotSpeed;
		}
	}

	void ShootRight()
	{
		if (toRight)
		{
			GameObject shoot =
				Instantiate(bullet, transform.position + Vector3.right, Quaternion.identity);

			Bullet shootBullet = shoot.GetComponent<Bullet>();

			shootBullet.TowardRight = true;
			shootBullet.Speed = shotSpeed;
		}
	}

	void ShootDown()
	{
		if (toDown)
		{
			GameObject shoot =
				Instantiate(bullet, transform.position + Vector3.down, Quaternion.identity);

			Bullet shootBullet = shoot.GetComponent<Bullet>();

			shootBullet.TowardDown = true;
			shootBullet.Speed = shotSpeed;
		}
	}

	void ShootLeft()
	{
		if (toLeft)
		{
			GameObject shoot =
				Instantiate(bullet, transform.position + Vector3.left, Quaternion.identity);

			Bullet shootBullet = shoot.GetComponent<Bullet>();

			shootBullet.TowardLeft = true;
			shootBullet.Speed = shotSpeed;
		}
	}
}
