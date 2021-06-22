using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //RigitBodyコンポーネントの操作を行うため、Rigitbodyコンポーネントを取得して代入するための変数
    private Rigidbody rb;

    //Header属性を変数の宣言に追加するとインスペクター上に（　）内に記述した文字が表示される
    [Header("移動速度")]
    public float moveSpeed;

    [Header("加速速度")]
    public float accelerationSpeed;

    [SerializeField]
    //制御を行うPhysicsMaterialをインスペクターから登録して値として代入
    private PhysicMaterial pmNoFriction;

    void Start()
    {
        //このスクリプトがアタッチされているゲームオブジェクトが持っているRigidbodyコンポーネントの情報をｒｂ変数に代入
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() //Updateメソッドではないので注意
    {
        //移動
        Move();
    }

    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        //キーボードの左右矢印のキー入力を判定し、-1.0f ～ 1.0fまでの値を代入
        float x = Input.GetAxis("Horizontal");

        //RigitbodyのVelocity(速度)に、キー入力の判定値と移動速度を代入してキャラを移動
        rb.velocity = new Vector3(x * moveSpeed, rb.velocity.y, rb.velocity.z);

        Debug.Log(rb.velocity);
    }

    private void Update()
    {
        //ブレーキ
        Brake();

        //加速
        Accelerate();

    }



    /// <summary>
    /// ブレーキ
    /// </summary>
    private void Brake()
    {
        //上下方向のキー入力を受け付けて値を代入
        float vertical = Input.GetAxis("Vertical");

        //取得した値が０よりも小さい値（下方向のキー入力）なら
        if(vertical < 0)
        {
            //NoFrictionのDynamicFrictionの値をジョジョに大きくする
            pmNoFriction.dynamicFriction += Time.deltaTime;

            //もしもDynamicFrictionの値が最大値である1.0fを超えたら
            if (pmNoFriction.dynamicFriction > 1.0f) 
            {
                //1.0fで停止する。
                pmNoFriction.dynamicFriction = 1.0f;

            }
        }

        //取得した値が０、あるいは０よりも大きな値（キー入力なし、あるいは上方向のキー入力なら）
        else
        {
            //摩擦を０に戻す　＝＞　再び滑り始めるようになる
            pmNoFriction.dynamicFriction = 0;
        }
    }

    /// <summary>
    /// 加速
    /// </summary>
    private void Accelerate()
    {
        //上下方向のキー入力を受け付けて値を代入
        float vertical = Input.GetAxis("Vertical");

        //取得した値が０よりも大きな値（上方向のキー入力）なら
        if(vertical > 0)
        {
            //滑り落ちている速度（VelocityのZ）を変更して加速させる
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, accelerationSpeed);
        }
    }

}
