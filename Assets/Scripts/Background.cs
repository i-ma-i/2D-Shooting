using UnityEngine;

public class Background : MonoBehaviour
{
    // �X�N���[������X�s�[�h
    public float speed = 0.1f;

    void Update()
    {
        // ���Ԃɂ����Y�̒l��0����1�ɕω����Ă����B1�ɂȂ�����0�ɖ߂�A�J��Ԃ��B
        float y = Mathf.Repeat(Time.time * speed, 1);

        // Y�̒l������Ă����I�t�Z�b�g���쐬
        Vector2 offset = new Vector2(0, y);

        // �}�e���A���ɃI�t�Z�b�g��ݒ肷��
        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}