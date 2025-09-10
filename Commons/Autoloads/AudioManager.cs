using Godot;
using Sounds;
using System;


namespace Commons.Autoloads
{
    public partial class AudioManager : Node
    {

        public static AudioManager Instance { get; private set; }

        [Export]
        private PackedScene _audioScene;

        public override void _Ready()
        {
            if (Instance != null)
            {
                QueueFree();
                return;
            }
            Instance = this;
        }

        private TempAudioPlayer InstantiateAudioMonoNode()
        {
            return _audioScene.Instantiate<TempAudioPlayer>();
        }

        public void PlaySound(AudioStream audio, float minPitch = 1, float maxPitch = 1, string audioBus = "Master")
        {
            var audioNode = InstantiateAudioMonoNode();
            audioNode.Stream = audio;
            float randPitch = GameManager.Instance.RNG.RandfRange(minPitch, maxPitch);
            audioNode.Bus = audioBus;
            AddChild(audioNode);
            audioNode.Play();
        }
    }
}
