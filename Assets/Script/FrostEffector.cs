using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostEffector : MonoBehaviour
{
    //���̃G�t�F�N�g��FrostAmount�̒l�̉��Z�l
    private float duration = 0.2f;

    //�P�񂾂����̃G�t�F�N�g�𔭐������邽�߂̐���p�̔���l�Bfalse�Ȃ疢�ڐG�Atrue�Ȃ�ڐG��
    private bool isApplyEffected;

    private RotateObject rotateObject;

    private void Start()
    {
        TryGetComponent(out rotateObject);
    }

    private void OnCollisionEnter(Collision col)
    {
        //Player�^�O�����Q�[���I�u�W�F�N�g�i�y���M���j�ƐڐG�����ۂɁA�܂��P����ڐG������s���Ă��Ȃ�(isApplyEffected�̒l��false�ł���)�ꍇ
        if(col.gameObject.tag == "Player" && isApplyEffected == false)
        {
            //������ڐG���邱�Ƃ�z�肵�A�P�񂾂����̃G�t�F�N�g�𔭐�������悤�ɏ����𐧌䂷��
            isApplyEffected = true;

            //MainCamera�^�O�̂��Ă���Q�[���I�u�W�F�N�g���q�G�����L�[����T���āA���̃Q�[���I�u�W�F�N�g�ɃA�^�b�`����Ă���FrostEffectController�X�N���v�g�̏����擾��
            //FrostEffectController�X�N���v�g���ɂ���UpdateFrostAmount���\�b�h���Ăяo�����߂��s���B�����Ƃ���duration�ϐ��̒l��n��
            Camera.main.gameObject.GetComponent<FrostEffectController>().UpdateFrostAmount(duration);

            //rotateObject�ϐ��Ŏw�肵��RotateObject�^�̏��Null�łȂ��ꍇ
            if(rotateObject != null)
            {
                rotateObject.StopTween();
            }


            //���̃Q�[���I�u�w�N�g��j������@�����@�Q�[����ʂɎc���Ă��������ꍇ�ɂ͂��̕����͏���
            Destroy(gameObject, 0.5f);

        }

    }
    
        
    
}
