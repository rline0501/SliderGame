using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{

    //�T�[�N���ɃL�������N���������Ɋl���ł��链�_�l�B�C���X�y�N�^�[���ݒ肷��
    public int point;
    
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("�L�����N��");

            //col.gameObject(�܂�penguin�Q�[���I�u�W�F�N�g)�ɑ΂��āATryGetComponent���\�b�h�����s��
            //PlayerController�N���X�̏����擾�ł��邩���肷��
            if(col.gameObject.TryGetComponent(out PlayerController player))
            {
                //Circle�̃Q�[���I�u�W�F�N�g���̂��̂�player�i�y���M���j�Ɏ�荞��
                transform.SetParent(player.transform);

                //PlayerController�N���X���擾�ł��Ă���ꍇ�A
                //player�ϐ���ʂ���PlayerController�N���X�ɋL�q����Ă���public�C���q��Addscore���\�b�h���Ăяo�����߂�����
                player.AddScore(point);
            }

        }

        Destroy(gameObject, 0.3f);
        
    }

}
