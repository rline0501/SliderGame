using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //RigitBody�R���|�[�l���g�̑�����s�����߁ARigitbody�R���|�[�l���g���擾���đ�����邽�߂̕ϐ�
    private Rigidbody rb;

    //���@private�C���q���m�͓��������ɂ܂Ƃ߂ď����Ɠǂ݂₷���Ȃ�
    private bool isGoal;

    //���x�����������邽�߂̌W��
    private float coefficient = 0.985f;

    //�������ɁA���̒l�ȉ��ɂȂ������~�����鑬�x�̒l
    private float stopValue = 2.5f;

    //Animator�R���|�[�l���g�̑�����s�����߁AAnimator�R���|�[�l���g���擾���đ�����邽�߂̕ϐ�
    private Animator anim;

    //�X�R�A�Ǘ��p�̕ϐ��BCircle�Q�[���I�u�W�F�N�g��ʉ߂��邽�тɂ��̒l�����Z���Ă���
    private int score;

    //Header������ϐ��̐錾�ɒǉ�����ƃC���X�y�N�^�[��Ɂi�@�j���ɋL�q�����������\�������
    [Header("�ړ����x")]
    public float moveSpeed;

    [Header("�������x")]
    public float accelerationSpeed;

    [Header("�W�����v��")]
    public float jumpPower;

    [SerializeField]
    //������s��PhysicsMaterial���C���X�y�N�^�[����o�^���Ēl�Ƃ��đ��
    private PhysicMaterial pmNoFriction;

    [SerializeField, Header("�n�ʔ���p���C���[")]
    private LayerMask groundLayer;

    [SerializeField, Header("�ΖʂƂ̐ڒn����")]
    private bool isGrounded;

    [SerializeField]
    //UIManager�X�N���v�g�𗘗p���邽�߂�UIManager�X�N���v�g�̏���������ϐ�
    private UIManager uIManager;


    void Start()
    {
        //���̃X�N���v�g���A�^�b�`����Ă���Q�[���I�u�W�F�N�g�������Ă���Rigidbody�R���|�[�l���g�̏����擾���Ă����ϐ��ɑ��
        rb = GetComponent<Rigidbody>();

        //���̃X�N���v�g���A�^�b�`����Ă���Q�[���I�u�W�F�N�g�������Ă���Rigidbody�R���|�[�l���g�̏����擾���Ă����ϐ��ɑ��
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate() //Update���\�b�h�ł͂Ȃ��̂Œ���
    {
        //�ړ�
        Move();
    }

    /// <summary>
    /// �ړ�
    /// </summary>
    private void Move()
    {
        //�S�[���n�_��ʉ߂�����
        if(isGoal == true)
        {
            //�����ŏ����𒆒f����@�����@����if���������ɏ����Ă��鏈�������s����Ȃ��Ȃ�
            return;
        }

        //�L�[�{�[�h�̍��E���̃L�[���͂𔻒肵�A-1.0f �` 1.0f�܂ł̒l����
        float x = Input.GetAxis("Horizontal");

        //Rigitbody��Velocity(���x)�ɁA�L�[���͂̔���l�ƈړ����x�������ăL�������ړ�
        rb.velocity = new Vector3(x * moveSpeed, rb.velocity.y, rb.velocity.z);

        //Debug.Log(rb.velocity);
    }

    private void Update()
    {
        //�u���[�L
        Brake();

        //����
        Accelerate();

        //�S�[���n�_��ʉ߂�����
        if(isGoal == true)
        {
            //�L�����̑��x�����X�ɉ�����
            rb.velocity *= coefficient;

            //���xZ�̒l�i���藎���鑬�x�j���K��l�����������Ȃ�����
            if (rb.velocity.z <= stopValue)
            {
                //���x���O�ɂ��Ē�~������
                rb.velocity = Vector3.zero;

                //�������Z�̏������~����
                rb.isKinematic = true;
            }
        }

        //�ڒn����
        CheckGround();

        //�X�y�[�X�L�[���������Ƃ��A�Ζʂ̃Q�[���I�u�W�F�N�g�ƃL�������ݒu���Ă���ꍇ
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            

            //�W�����v
            Jump();
        }

    }




    /// <summary>
    /// �u���[�L
    /// </summary>
    private void Brake()
    {
        //�㉺�����̃L�[���͂��󂯕t���Ēl����
        float vertical = Input.GetAxis("Vertical");

        //�擾�����l���O�����������l�i�������̃L�[���́j�Ȃ�
        if(vertical < 0)
        {
            //NoFriction��DynamicFriction�̒l���W���W���ɑ傫������
            pmNoFriction.dynamicFriction += Time.deltaTime;

            //������DynamicFriction�̒l���ő�l�ł���1.0f�𒴂�����
            if (pmNoFriction.dynamicFriction > 1.0f) 
            {
                //1.0f�Œ�~����B
                pmNoFriction.dynamicFriction = 1.0f;

            }
        }

        //�擾�����l���O�A���邢�͂O�����傫�Ȓl�i�L�[���͂Ȃ��A���邢�͏�����̃L�[���͂Ȃ�j
        else
        {
            //���C���O�ɖ߂��@�����@�Ăъ���n�߂�悤�ɂȂ�
            pmNoFriction.dynamicFriction = 0;
        }
    }

    /// <summary>
    /// ����
    /// </summary>
    private void Accelerate()
    {
        //�㉺�����̃L�[���͂��󂯕t���Ēl����
        float vertical = Input.GetAxis("Vertical");

        //�擾�����l���O�����傫�Ȓl�i������̃L�[���́j�Ȃ�
        if(vertical > 0)
        {
            //���藎���Ă��鑬�x�iVelocity��Z�j��ύX���ĉ���������
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, accelerationSpeed);
        }
    }

    //ISTrigger���I���̃R���C�_�[�����Q�[���I�u�W�F�N�g��ʉ߂����ꍇ�ɌĂяo�����A�R�[���o�b�N�E���\�b�h
    private void OnTriggerEnter(Collider other)
    {
        //�N�������R���C�_�[�̃Q�[���I�u�W�F�N�g��Tag��Goal�Ȃ�i����ȊO��Tag�Ȃ�ȉ��̏������s��Ȃ��j
        if(other.gameObject.tag == "Goal")
        {
            Debug.Log("Goal");

            //�S�[���n�_��ʉ߂�����Ԃɂ���
            isGoal = true;

            Debug.Log(isGoal);
        }
    }

    private void Jump()
    {
        //�L�����ɏ�����̗͂������
        rb.AddForce(transform.up * jumpPower);

        //�����Ŏw�肵���p�����[�^�[���Đ�������
        anim.SetTrigger("jump");
    }

    /// <summary>
    /// �ΖʂƂ̐ڐG����Btrue�Ȃ�ڒn���Ă����ԁBfalse�͐ڒn���Ă��Ȃ���Ԃƒ�`����
    /// </summary>
    private void CheckGround()
    {
        //Linecast���\�b�h�����s���ăL�����̑����Ɍ����Č����Ȃ�Line���΂�
        //Line��groundLayer�ϐ��Ŏw�肵��Layer(Ground)�����Q�[���I�u�W�F�N�g���ڐG���邩����B�Ώۂ�Layer�̎���true��Ԃ�
        isGrounded = Physics.Linecast(transform.position, transform.position - transform.up * 0.3f, groundLayer);

        //
        Debug.DrawLine(transform.position, transform.position - transform.up * 0.3f, Color.red);
    }

    /// <summary>
    /// �X�R�A���Z
    /// </summary>
    /// <param name="amount"></param>
    public void AddScore(int amount)
    {
        //�X�R�A���Z
        score += amount;

        //���̂܂�score�Ƃ��������Ɏw�肵�Ă��\������邪�A����ł͐��������\������Ȃ����߁A
        //�킩��₷���悤�ɕ�������ꏏ�ɕ\�������Ă���
        Debug.Log("���݂̓��_ :" + score);

        //UIManager�̏�񂪑������Ă���ϐ��𗘗p����UIManader�X�N���v�g��UpdateDisplayScore���\�b�h���Ăяo�����������s����
        //�����Ƃ���score�ϐ��̒l��n�����ƂŁA�󂯎�������\�b�h�����̒l�𗘗p�ł���B
        //���̎��_��score�ϐ��ɂ�Circle�X�N���v�g����͂��Ă���point�̒l�����Z����Ă��邽�ߍŐV���
        uIManager.UpdateDisplayScore(score);
    }
}
