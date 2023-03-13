using System;

namespace Data.ValueObject
{
    [Serializable]
    public class InputData
    {
        public float PlayerInputSpeed = 2f;
        public float ClampSpeed = 0.007f;
    }
}