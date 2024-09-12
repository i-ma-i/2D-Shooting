using UnityEngine;
using System.Collections;

public class Emitter : MonoBehaviour
{
    // Wave�v���n�u���i�[����
    public GameObject[] waves;

    // ���݂�Wave
    private int currentWave;

    // Manager�R���|�[�l���g
    private Manager manager;

    IEnumerator Start()
    {

        // Wave�����݂��Ȃ���΃R���[�`�����I������
        if (waves.Length == 0)
        {
            yield break;
        }

        // Manager�R���|�[�l���g���V�[��������T���Ď擾����
        manager = FindObjectOfType<Manager>();

        while (true)
        {

            // �^�C�g���\�����͑ҋ@
            while (manager.IsPlaying() == false)
            {
                yield return new WaitForEndOfFrame();
            }

            // Wave���쐬����
            GameObject g = (GameObject)Instantiate(waves[currentWave], transform.position, Quaternion.identity);

            // Wave��Emitter�̎q�v�f�ɂ���
            g.transform.parent = transform;

            // Wave�̎q�v�f��Enemy���S�č폜�����܂őҋ@����
            while (g.transform.childCount != 0)
            {
                yield return new WaitForEndOfFrame();
            }

            // Wave�̍폜
            Destroy(g);

            // �i�[����Ă���Wave��S�Ď��s������currentWave��0�ɂ���i�ŏ����� -> ���[�v�j
            if (waves.Length <= ++currentWave)
            {
                currentWave = 0;
            }

        }
    }
}