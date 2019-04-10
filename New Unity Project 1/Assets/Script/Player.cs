using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float Speed = 20;
    public GameObject pickup;
    private Rigidbody rb; 
    // Use this for initialization
    //スタート内はコンストラクタのように最初に一回だけ通過する
    void Start () {
        rb = GetComponent<Rigidbody>();
        	
	}
	
	// Update is called once per frame
	void Update () {

        //カーソルキーの入力を取得
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        //カーソルキーの入力に合わせて移動方向を設定
        var movement = new Vector3(moveHorizontal, 0, moveVertical);

        //Ridigbody に力を与えて玉を動かす
        rb.AddForce(movement * Speed);

    }


    //当たり判定
    void OnCollisionEnter(Collision other)
    {
        //ぶつかったオブジェクトが収集アイテムだった場合
        if (other.gameObject.CompareTag("PickUp"))
        {
            //その収集アイテムを非表示にします
            //other.gameObject.SetActive(false);
            Destroy(other.gameObject);
            //新たに収集アイテムを出現させる
            GameObject work_pick = Instantiate(pickup);
            work_pick.transform.position = new Vector3(Random.Range(0, 5), 0.5f, Random.Range(0, 5));

            //規定数回収したらクリア画面に行く

        }
    }



}

