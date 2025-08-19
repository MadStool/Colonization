using UnityEngine;

public class SimpleFlagPlacer : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Camera _gameCamera;
    [SerializeField] private Flag _flagPrefab;

    private Flag _currentFlag;
    private bool _isPlacingMode = false;

    private void Start()
    {
        _currentFlag = Instantiate(_flagPrefab, Vector3.zero, Quaternion.identity);
        _currentFlag.Hide();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isPlacingMode)
            {
                TryPlaceFlag();
            }
            else
            {
                CheckBaseClick();
            }
        }

        if (Input.GetMouseButtonDown(1) && _isPlacingMode)
        {
            CancelPlacingMode();
        }
    }

    private void CheckBaseClick()
    {
        Ray ray = _gameCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f))
        {
            if (hit.collider.gameObject == gameObject)
            {
                StartPlacingMode();
            }
        }
    }

    private void StartPlacingMode()
    {
        _isPlacingMode = true;
    }

    private void TryPlaceFlag()
    {
        Ray ray = _gameCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f, _groundLayer))
        {
            _currentFlag.PlaceAt(hit.point);
            _isPlacingMode = false;
        }
    }

    private void CancelPlacingMode()
    {
        _isPlacingMode = false;
        _currentFlag.Hide();
    }
}