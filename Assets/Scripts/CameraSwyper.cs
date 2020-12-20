//Скрипт вешается на камеру и предназначен для её плавного перемещения при зажатии мыши, как в MOBA-играх

using UnityEngine;


public class CameraSwyper : MonoBehaviour
{
    

    [SerializeField] private float Speed;

    [SerializeField] private Vector3 _startPos;
    [SerializeField] private Camera _cam;
    [SerializeField] private float _targetPosZ;
    [SerializeField] private float _targetPosX;

    [SerializeField] private float _maxPosX;
    [SerializeField] private float _minPosX;

    [SerializeField] private float _maxPosZ;
    [SerializeField] private float _minPosZ;

  

    void Start()
    {
        _cam = GetComponent<Camera>();
        _targetPosZ = transform.position.z;
        _targetPosX = transform.position.x;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _startPos = _cam.ScreenToViewportPoint(Input.mousePosition);
        }


        else if (Input.GetMouseButton(0))
        {
            float posY = _cam.ScreenToViewportPoint(Input.mousePosition).y - _startPos.y;
            _targetPosZ = Mathf.Clamp(transform.position.x - posY, _minPosX, _maxPosX);

            float posX = _cam.ScreenToViewportPoint(Input.mousePosition).x - _startPos.x;
            _targetPosX = Mathf.Clamp(transform.position.z + posX, _minPosZ, _maxPosZ);

        }
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, _targetPosZ, Speed * Time.deltaTime),
            transform.position.y,
            Mathf.Lerp(transform.position.z, _targetPosX, Speed * Time.deltaTime));
    }
}
