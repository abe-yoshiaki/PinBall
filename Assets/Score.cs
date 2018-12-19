using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    //得点
    private int point = 0;
    //得点表示するテキスト
    private GameObject scoreText;
    // Use this for initialization
    void Start () {
        this.scoreText = GameObject.Find("Score");
	}
	
	// Update is called once per frame
	void Update () {
       
    }

    //衝突判定
    private void OnCollisionStay(Collision other)
    {
        string tag = other.gameObject.tag;

        if(tag == "SmallStarTag")
        {
            this.point += 10; 
        }
        else if (tag == "LargeStarTag")
        {
            this.point += 20;
        }
        else if (tag == "SmallCloudTag" || tag == "LargeCloudTag")
        {
            this.point += 30;
        }
        this.scoreText.GetComponent<Text>().text = "Score:" + this.point + "pt";
    }
}
