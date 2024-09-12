using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class Spaceship : MonoBehaviour
{
    // �ړ��X�s�[�h
    public float speed;

    // �e�����Ԋu
    public float shotDelay;

    // �e��Prefab
    public GameObject bullet;

    // �e�������ǂ���
    public bool canShot;

    // ������Prefab
    public GameObject explosion;

    // �A�j���[�^�[�R���|�[�l���g
    private Animator animator;

    void Start()
    {
        // �A�j���[�^�[�R���|�[�l���g���擾
        animator = GetComponent<Animator>();
    }

    // �����̍쐬
    public void Explosion()
    {
        Instantiate(explosion, transform.position, transform.rotation);
    }

    // �e�̍쐬
    public void Shot(Transform origin)
    {
        Instantiate(bullet, origin.position, origin.rotation);
    }

    // �A�j���[�^�[�R���|�[�l���g�̎擾
    public Animator GetAnimator()
    {
        return animator;
    }
}