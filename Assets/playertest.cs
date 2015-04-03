using UnityEngine;
using System.Collections;

public class playertest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
        public float speed = 5;
	// Update is called once per frame
	void Update () {
		        // 右・左
                float x = Input.GetAxisRaw ("Horizontal");

                // 上・下
                float z = Input.GetAxisRaw ("Vertical");

                // 移動する向きを求める
                Vector3 direction = new Vector3 (x, 0, z).normalized;

                // 移動する向きとスピードを代入する
                rigidbody.velocity = direction * speed;
				if(Input.GetKeyDown("space")){
					rigidbody.AddForce(Vector3.up * 400f);
				}
	}
}
