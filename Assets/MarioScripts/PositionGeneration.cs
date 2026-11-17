using UnityEngine;

public class PositionGeneration
{
    private Vector2 _position;

    private float _maxYPosition;
    private float _minYPosition;

    private float _maxXPosition;
    private float _minXPosition;

    public PositionGeneration(float maxYPosition, float minYPosition, float maxXPosition, float minXPosition)
    {
        _maxYPosition = maxYPosition;
        _minYPosition = minYPosition;

        _maxXPosition = maxXPosition;
        _minXPosition = minXPosition;
    }

    private Vector2 GeneratePosition()
    {
        return new Vector2(Random.Range(_minXPosition, _maxXPosition), Random.Range(_minYPosition, _maxYPosition));
    }

    public Vector2 GetPosition()
    {
        _position = GeneratePosition();
        return _position;
    }
}
