using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    // Spaceship�R���|�[�l���g
    Spaceship spaceship;

    IEnumerator Start()
    {
        // Spaceship�R���|�[�l���g���擾
        spaceship = GetComponent<Spaceship>();

        while (true)
        {

            // �e���v���C���[�Ɠ����ʒu/�p�x�ō쐬
            spaceship.Shot(transform);

            // �V���b�g����炷
            GetComponent<AudioSource>().Play();

            // shotDelay�b�҂�
            yield return new WaitForSeconds(spaceship.shotDelay);
        }
    }

    void Update()
    {
        // �E�E��
        float x = Input.GetAxisRaw("Horizontal");

        // ��E��
        float y = Input.GetAxisRaw("Vertical");

        // �ړ�������������߂�
        Vector2 direction = new Vector2(x, y).normalized;

        // �ړ��̐���
        Move(direction);

    }

    // �@�̂̈ړ�
    void Move(Vector2 direction)
    {
        // ��ʍ����̃��[���h���W���r���[�|�[�g����擾
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        // ��ʉE��̃��[���h���W���r���[�|�[�g����擾
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        // �v���C���[�̍��W���擾
        Vector2 pos = transform.position;

        // �ړ��ʂ�������
        pos += direction * spaceship.speed * Time.deltaTime;

        // �v���C���[�̈ʒu����ʓ��Ɏ��܂�悤�ɐ�����������
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        // �������������l���v���C���[�̈ʒu�Ƃ���
        transform.position = pos;
    }

    // �Ԃ������u�ԂɌĂяo�����
    void OnTriggerEnter2D(Collider2D c)
    {
        // ���C���[�����擾
        string layerName = LayerMask.LayerToName(c.gameObject.layer);

        // ���C���[����Bullet (Enemy)�̎��͒e���폜
        if (layerName == "Bullet (Enemy)")
        {
            // �e�̍폜
            Destroy(c.gameObject);
        }

        // ���C���[����Bullet (Enemy)�܂���Enemy�̏ꍇ�͔���
        if (layerName == "Bullet (Enemy)" || layerName == "Enemy")
        {
            // Manager�R���|�[�l���g���V�[��������T���Ď擾���AGameOver���\�b�h���Ăяo��
            FindObjectOfType<Manager>().GameOver();

            // ��������
            spaceship.Explosion();

            // �v���C���[���폜
            Destroy(gameObject);
        }
    }
}