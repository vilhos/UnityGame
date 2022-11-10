using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyAnimation : MonoBehaviour
{
	public Sprite stay_Pos;
	public Sprite walk_Pos;
	public SpriteRenderer rubby_View;
	public float speed;
	private bool is_Walk =false;

	void Change_Picture()
	{
		if(is_Walk)
		{
			rubby_View.sprite=stay_Pos;
			is_Walk=false;
		}
		else
		{
			rubby_View.sprite=walk_Pos;
			is_Walk=true;
		}
	}
    public void Start_Walk()
    {
		InvokeRepeating("Change_Picture",0,speed);
    }

    public void Stop_Walk()
    {
		CancelInvoke("Change_Picture");
		rubby_View.sprite=stay_Pos;
    }
}
