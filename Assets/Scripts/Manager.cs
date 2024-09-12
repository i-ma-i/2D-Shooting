using UnityEngine;

public class Manager : MonoBehaviour
{
    // Player�v���n�u
    public GameObject player;

    // �^�C�g��
    private GameObject title;

    void Start()
    {
        // Title�Q�[���I�u�W�F�N�g���������擾����
        title = GameObject.Find("Title");
        if (title == null)
        {
            Debug.Log("Title��������܂���");
        }
    }

    void Update()
    {
        // �Q�[�����ł͂Ȃ��A�}�E�X�N���b�N���ꂽ��true��Ԃ��B
        if (IsPlaying() == false && Input.GetMouseButtonDown(0))
        {
            GameStart();
        }
    }

    void GameStart()
    {
        // �Q�[���X�^�[�g���ɁA�^�C�g�����\���ɂ��ăv���C���[���쐬����
        title.SetActive(false);
        Instantiate(player, player.transform.position, player.transform.rotation);
    }

    public void GameOver()
    {
        // �Q�[���I�[�o�[���ɁA�^�C�g����\������
        title.SetActive(true);
    }

    public bool IsPlaying()
    {
        // �Q�[�������ǂ����̓^�C�g���̕\��/��\���Ŕ��f����
        return title.activeSelf == false;
    }
}