using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostEffectController : MonoBehaviour
{
    //Frostスクリプトを代入して操作するための変数
    private FrostEffect frostEffect;

    //FrostAmountの値とリンクさせるための変数
    private float currentFrostvalue;

    void Start()
    {
        //同じゲームオブジェクトにアタッチされているFrostEffectスクリプトを取得して代入
        frostEffect = GetComponent<FrostEffect>();

        //霜エフェクトの初期化（霜エフェクトが画面に見えないようにする）
        InitialFrostAmount();
    }

   
    void Update()
    {
        //currentFrostValueの値が０以上の時　＝＞　つまり、霜のエフェクトで画面が覆われているとき
        if(currentFrostvalue > 0)
        {
            //値を操作して、画面を少しずつ見えるようにする
            currentFrostvalue -= Time.deltaTime / 20;

            //操作した値でFrostAmountの値を更新する　＝＞　この処理で霜のエフェクトが徐々に薄くなって消えていく
            UpdateFrostAmount(0);

            //currentFrostValueの値が０以下になった時　＝＞　霜のエフェクトをなくしてよい状態になったら
            if(currentFrostvalue <= 0)
            {
                //次の霜のエフェクト発生に備えてFrostAmountの値を０に戻して初期化しておく
                InitialFrostAmount();
            }
        }
        
    }

    /// <summary>
    /// FrostEffectのFrostAmountの値を更新
    /// </summary>
    /// <param name="amount"></param>
    public void UpdateFrostAmount(float amount)
    {
        currentFrostvalue += amount;
        frostEffect.FrostAmount = currentFrostvalue;
    }

    /// <summary>
    /// FrostEffectのFrostAmountの値の初期化
    /// </summary>
    public void InitialFrostAmount()
    {
        currentFrostvalue = 0;
        frostEffect.FrostAmount = currentFrostvalue;
    }
}
