using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//добавил лишнюю строчку
public class ChangeSkins : MonoBehaviour {
	public Sprite[] sprite;
	public Transform ChangeAbleSkin;
	private int i = 1;
	private Image img;
	public Button Left, Right;
	
	void Start()
	{
		if (i==0)
			Left.gameObject.SetActive(false);
		if (i == sprite.Length)
			Right.gameObject.SetActive(false);
	}

	public void NextSkin()
	{
		if (i>-1)
		{
			Left.gameObject.SetActive(true);
		}
			img = ChangeAbleSkin.GetComponent<Image>();

		if (i+2 == sprite.Length)
		{
			
			Right.gameObject.SetActive(false);
			i++;
			img.sprite = sprite[i];
		}
		else
		{
			i++;
			img.sprite = sprite[i];
			

		}
	}
	public void LastSkin()
	{
		img = ChangeAbleSkin.GetComponent<Image>();
		if (i!=sprite.Length)
		{
			Right.gameObject.SetActive(true);
		}

		if (i - 1 == 0)
		{

			Left.gameObject.SetActive(false);
			i--;
			img.sprite = sprite[i];
		}
		else
		{
			
			i -= 1;
			img.sprite = sprite[i];
		}
	}
}
