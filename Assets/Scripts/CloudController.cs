using System.Collections;
using UnityEngine;

public class CloudController : MonoBehaviour {

    //最小サイズ
    private float minimum = 1.0f;
    //拡大縮小スピード
    private float magSpeed = 5.0f;
    //拡大率
    private float magnification = 0.07f;

	void Start () {
		
	}
	
	void Update () {
        //雲を拡大縮小
        this.transform.localScale = new Vector3(
            this.minimum + Mathf.Sin(Time.time * this.magSpeed) * this.magnification,
            this.transform.localScale.y,
            this.minimum + Mathf.Sin(Time.time * this.magSpeed) * this.magnification
            );

    }
}
