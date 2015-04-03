using UnityEngine;
using System.Collections;

public class touch : MonoBehaviour {

	public GameObject canon;		//大砲
	public GameObject canonball;	//弾（プレハブ）
	public float shotpower;			//射出力（速度）

	private Vector3 bases;			
	private GameObject ball;
	private Vector3 shooter;
	private float rad;
	private float sita;

//	public GameObject test;
	// Use this for initialization
	void Start () {
		bases = canon.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//タッチ処理
		if(Input.touchCount > 0){
			if(Input.GetTouch(0).phase == TouchPhase.Began||Input.GetMouseButtonDown(0)){
				//大砲からクリック位置までの差分　いわゆる射線 タッチのpositionはvector2なので変換する。
				//shooter = new Vector3(Input.GetTouch(0).position.x , Input.GetTouch(0).position.y ,0) - bases;
				shooter = (Vector3)Input.GetTouch(0).position - bases;
				//右方向を基準にした射線の角度
				sita = Vector3.Angle(Vector3.right,shooter);
				//マイナスの角度に対応
				if(shooter.y < 0) sita = -sita;
				//オイラー角からラジアンへ変換
				rad = Mathf.Deg2Rad * sita;
				//弾を大砲の位置に生成
				ball = (GameObject) Instantiate(canonball,canon.transform.position,canonball.transform.rotation);
				//弾をキャンバス内に入れる。大砲の回転に追従すると困るので、大砲と兄弟関係になるように。
				ball.transform.SetParent(canon.transform.parent);
				//大砲の角度をθに
				canon.transform.eulerAngles = new Vector3(0,0,sita);
				//弾の発射
				ball.rigidbody.AddForce(shotpower * Mathf.Cos(rad), shotpower * Mathf.Sin(rad)	,0);
				//時間経過で弾を消滅
				Destroy(ball, 2.0f);
				Debug.Log(sita);
			}
		}

		//マウス用処理
		if(Input.GetMouseButtonDown(0)){
				//大砲からクリック位置までの差分　いわゆる射線
				shooter = Input.mousePosition - bases;
				//右方向を基準にした射線の角度
				sita = Vector3.Angle(Vector3.right,shooter);
				//マイナスの角度に対応
				if(shooter.y < 0) sita = -sita;
				//オイラー角からラジアンへ変換
				rad = Mathf.Deg2Rad * sita;
				//弾を大砲の位置に生成
				ball = (GameObject) Instantiate(canonball,canon.transform.position,canonball.transform.rotation);
				//弾をキャンバス内に入れる。大砲の回転に追従すると困るので、大砲と兄弟関係になるように。
				ball.transform.SetParent(canon.transform.parent);
				//大砲の角度をθに
				canon.transform.eulerAngles = new Vector3(0,0,sita);
				//弾の発射
				ball.rigidbody.AddForce(shotpower * Mathf.Cos(rad), shotpower * Mathf.Sin(rad)	,0);
				//時間経過で弾を消滅
				Destroy(ball, 2.0f);
				Debug.Log(sita);
		}
	}
}
