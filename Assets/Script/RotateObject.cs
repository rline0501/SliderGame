using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotateObject : MonoBehaviour
{
    [Header("��]���鎞��")]
    public float duration;

    //��]���Ă��邩�A�܂����Ă��Ȃ����̏�Ԃ�ݒ肷�邽�߂̒l�Bfalse�Ȃ�܂���]���Ă��Ȃ��B
    private bool isRotate = false;

    private Tween tween;

    private void OnTriggerEnter(Collider col)
    {
        //�L���������̋����ɓ��������A�܂���]���Ă��Ȃ���ԂłȂ��Ȃ�
        if (col.gameObject.tag == "Player" && isRotate == false)
        {
            //�؂���]�����ē|��
            Rotate();

            //��]���ē]�|������Ԃɂ���
            isRotate = true;
        }
    }

    /// <summary>
    /// �؂���]������
    /// </summary>
    private void Rotate()
    {
        //Z���̂�duration���̎��Ԃ������ĉ�]�B��]���x��RandomAngle���\�b�h�̖߂�l�𗘗p���āA�����_���ɍ��E�ɓ|���悤�ɂ���
        tween = transform.DORotate(new Vector3(0, 0, RandomAngle()), duration);
    }

    /// <summary>
    /// �؂̉�]�p�x�������_���ɐݒ�ifloat�^�̖߂�l������̂ŁA�������I�������float�^�̒l���������ɖ߂��j
    /// </summary>
    /// <returns></returns>
    private float RandomAngle()
    {
        //�����_���Ȓl���擾����value�ɑ���iRandom.Range() ���\�b�h���߂�l������܂��j
        int value = Random.Range(0, 2);

        //value�̒l���O�̏ꍇ
        if(value == 0)
        {
            //70.0f���Ăяo�����ɖ߂�
            return 70.0f;
        }
        //value�̒l���P�̏ꍇ
        else
        {
            //-70.0f���Ăяo�����ɖ߂�
            return -70.0f;
        }

        //���̈�A�̋L�q����s�ɊȌ�����������
        //return Random.Range(0, 2) == 0 ? 70 : -70;

    }

    public void StopTween()
    {
        tween.Kill();
    }
   
}
