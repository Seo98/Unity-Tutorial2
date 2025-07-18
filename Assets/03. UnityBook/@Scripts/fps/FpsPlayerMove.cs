using UnityEngine;

public class FPSPlayerMove : MonoBehaviour
{
    private CharacterController cc;

    public float moveSpeed = 7f;

    private float gravity = -20f;
    private float yVelocity = 0f;

    public float jumpPower = 5f;
    public bool isJumping = false;

    private float h;
    private float v;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v); // ũ��� ������ �ִ� ����
        dir = dir.normalized; // ���⸸ �ִ� ����

        // ī�޶��� Transform �������� ��ȯ
        dir = Camera.main.transform.TransformDirection(dir);

        // �߷� ����
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        cc.Move(dir * moveSpeed * Time.deltaTime); // ĳ���� ��Ʈ�ѷ��� ����� �̵� ���


        // none : �ƹ��͵� ���� ����
        // below : �ٴڿ� ����
        // adove : �Ӹ��� ����
        // sides : ���鿡 ����

        if(cc.collisionFlags == CollisionFlags.Below) // 
        {
            if(isJumping) isJumping = false;

            yVelocity = 0f; // �߷� �ʱ�ȭ�� ������ �߷��� ��� �����Ǳ� ������
            // �ʱ�ȭ�� ���ϸ� ������ �Ʒ��� ������ �ƴ�, �ܼ��������� �����̵� �ϴ� ������ �߻�
        }


        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            yVelocity = jumpPower;
            isJumping = true;
        }
    }
}