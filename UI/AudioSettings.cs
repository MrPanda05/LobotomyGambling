using Godot;
using System;

namespace UI
{
    public partial class AudioSettings : Control
    {
        [Export]
        private Control _previousNode;


        public override void _Ready()
        {
            if(_previousNode != null)
            {
                Visible = false;
            }
            else
            {
                Visible= true;
            }
        }

        public void OnReturnButttonButtonDown()
        {
            Visible = false;
            _previousNode.Visible = true;
        }


    }
}
