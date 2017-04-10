using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour
{
    // キューブの移動速度
    private float speed = -0.2f;
    // 消滅位置
    private float deadLine = -10;
    // ブロックが衝突した時のSEを鳴らすためのAudioSource
    private AudioSource audioSource;
    // ブロック音のAudioClip
    public AudioClip audioClip;

    /// <summary>
    /// スタート時に呼び出される処理。
    /// ブロック衝突時にSEを鳴らすために、予めAudioSourceを取得しておく。
    /// </summary>
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // キューブを移動させる
        transform.Translate(this.speed, 0, 0);

        // 画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 衝突時に呼び出される処理。
    /// ブロックがUnityちゃん以外のオブジェクトに衝突した場合にSEを鳴らす。
    /// </summary>
    /// <param name="other">衝突した相手のCollision2D</param>
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "UnityChanTag")
        {
            // ブロック衝突毎に衝突音が重なって再生されるように、PlayOneShot関数を用いる。
            audioSource.PlayOneShot(audioClip);
        }
    }
}