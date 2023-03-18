using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour {

	public GameObject btnMoNhac, btnTatNhac, btnListNhac, PanelListNhac;

	public Button btnNhac;
	private Sprite MoNhac;

	private Sprite TatNhac;
	private int counter = 0;

	public AudioClip NhacNen3;
	public AudioClip NhacNen2;
	public AudioClip NhacNen1;
	public AudioClip NhacGO;

	private AudioSource audioSource;
	void Start()
	{        
		btnNhac.GetComponent<Button>();
		audioSource = gameObject.GetComponent<AudioSource>();
		audioSource.Play();
		Unmute();

	}


	void Update () {

	}

	public void ChangeButtonAudio()
	{
		if (counter == 3)
			counter = 0;
		else
			counter++;
		switch (counter)
		{
		case 0:
			btnNhac.image.overrideSprite = MoNhac;
			audioSource.clip = NhacNen3;
			audioSource.Play();
			break;
		case 1:
			btnNhac.image.overrideSprite = MoNhac;
			audioSource.clip = NhacNen2;
			audioSource.Play();
			break;
		case 2:
			btnNhac.image.overrideSprite = MoNhac;
			audioSource.clip = NhacNen1;
			audioSource.Play();
			break;
		case 3:
			btnNhac.image.overrideSprite = TatNhac;
			audioSource.Stop();
			break;
		}




	}


	//Tắt Nhạc
	public void Mute()
	{       
		btnTatNhac.SetActive(true);
		//audioSource.Stop();
		AudioListener.volume = 0f;
		btnMoNhac.SetActive(false);
		//   Time.timeScale = 0;

	}


	//Mở Nhạc
	public void Unmute()
	{       
		btnTatNhac.SetActive(false);
		audioSource.clip = NhacNen3;
		AudioListener.volume = 1f;
		audioSource.Play();
		btnMoNhac.SetActive(true);
	}

	//Mở List nhac
	public void ListNhac()
	{       
		PanelListNhac.SetActive(true);
		btnListNhac.SetActive(false);
	}

	//Mở  nhạc nền 1
	public void MoNhacNen1()
	{      
		PanelListNhac.SetActive(false);
		btnListNhac.SetActive(true);
		audioSource.clip = NhacNen1;
		audioSource.Play();
	}

	//Mở  nhạc nền 3
	public void MoNhacNen2()
	{       
		PanelListNhac.SetActive(false);
		btnListNhac.SetActive(true);
		audioSource.clip = NhacNen2;
		audioSource.Play();
	}

	//Mở  nhạc nền 3
	public void MoNhacNen3()
	{
		PanelListNhac.SetActive(false);
		btnListNhac.SetActive(true);
		audioSource.clip = NhacNen3;
		audioSource.Play();
	}

}
