using System;
using System.Collections.Generic;
using System.Text;

namespace ModalNofications
{
    public class SupportModalClass
    {
        public enum NotificationType
        {
            error,
            success,
            warning,
            info
        }

        public enum Position
        {
            topLeft,
            topRight,
            bottomLeft,
            bottomRigth
        }

        public Dictionary<Position, string> position()
        {
            var positions = new Dictionary<Position, string>();

            positions.Add(Position.topLeft, "toast-top-left");
            positions.Add(Position.topRight, "toast-top-right");
            positions.Add(Position.bottomLeft, "toast-bottom-left");
            positions.Add(Position.bottomRigth, "toast-bottom-right");

            return positions;
        }
    }
}
