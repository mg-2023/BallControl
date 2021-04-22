using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlay : MonoBehaviour
{
	AudioSource BGM;

    // Start is called before the first frame update
    void Start()
	{
		BGM = gameObject.GetComponent<AudioSource>();

		BGM.Play();
	}

	/*
	// Update is called once per frame
	void Update()
	{
		
	}
	*/
}
