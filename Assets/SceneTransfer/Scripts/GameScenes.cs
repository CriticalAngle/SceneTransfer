namespace CriticalAngleStudios
{
    // ReSharper disable once PartialTypeWithSinglePart
    public partial class GameScenes
    {
        public string Value { get; }
        
        private GameScenes(string name)
        {
            Value = name;
        }
    }
}