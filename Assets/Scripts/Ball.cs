using UnityEngine;

internal sealed class Ball
{
    private Vector3 _startPos;
    private Color _color;
    private float _speed;
    private float _scale;

    public Vector3 StartPos
    {
        get { return _startPos; }
        set { _startPos = value; }
    }
    public Color Color
    {
        get { return _color; }
        set { _color = value; }
    }
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }
    public float Scale
    {
        get { return _scale; }
        set { _scale = value; }
    }

    public Ball(Vector3 startPos, Color collor, float speed, float scale)
    {
        _startPos = startPos;
        _color = collor;
        _speed = speed;
        _scale = scale;
    }
    public Ball()
    {
        System.Random rand = new System.Random();
        byte negative = (byte)rand.Next(0, 2);
        if (negative != 0)
        {
            _startPos = new Vector3((float)rand.NextDouble() * 14, 5, 0);
        }
        else
        {
            _startPos = new Vector3(-(float)rand.NextDouble() * 14, 5, 0);
        }

        float r = (float)rand.NextDouble();
        float g = (float)rand.NextDouble();
        float b = (float)rand.NextDouble();
        _color = new Color(r, g, b);

        _speed = (float)rand.Next(5, 15);
        _scale = _speed / 15;
        _speed = _speed / 500;
    }
}
