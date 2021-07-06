using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostEffectController : MonoBehaviour
{
    //Frost�X�N���v�g�������đ��삷�邽�߂̕ϐ�
    private FrostEffect frostEffect;

    //FrostAmount�̒l�ƃ����N�����邽�߂̕ϐ�
    private float currentFrostvalue;

    void Start()
    {
        //�����Q�[���I�u�W�F�N�g�ɃA�^�b�`����Ă���FrostEffect�X�N���v�g���擾���đ��
        frostEffect = GetComponent<FrostEffect>();

        //���G�t�F�N�g�̏������i���G�t�F�N�g����ʂɌ����Ȃ��悤�ɂ���j
        InitialFrostAmount();
    }

   
    void Update()
    {
        //currentFrostValue�̒l���O�ȏ�̎��@�����@�܂�A���̃G�t�F�N�g�ŉ�ʂ������Ă���Ƃ�
        if(currentFrostvalue > 0)
        {
            //�l�𑀍삵�āA��ʂ�������������悤�ɂ���
            currentFrostvalue -= Time.deltaTime / 20;

            //���삵���l��FrostAmount�̒l���X�V����@�����@���̏����ő��̃G�t�F�N�g�����X�ɔ����Ȃ��ď����Ă���
            UpdateFrostAmount(0);

            //currentFrostValue�̒l���O�ȉ��ɂȂ������@�����@���̃G�t�F�N�g���Ȃ����Ă悢��ԂɂȂ�����
            if(currentFrostvalue <= 0)
            {
                //���̑��̃G�t�F�N�g�����ɔ�����FrostAmount�̒l���O�ɖ߂��ď��������Ă���
                InitialFrostAmount();
            }
        }
        
    }

    /// <summary>
    /// FrostEffect��FrostAmount�̒l���X�V
    /// </summary>
    /// <param name="amount"></param>
    public void UpdateFrostAmount(float amount)
    {
        currentFrostvalue += amount;
        frostEffect.FrostAmount = currentFrostvalue;
    }

    /// <summary>
    /// FrostEffect��FrostAmount�̒l�̏�����
    /// </summary>
    public void InitialFrostAmount()
    {
        currentFrostvalue = 0;
        frostEffect.FrostAmount = currentFrostvalue;
    }
}
