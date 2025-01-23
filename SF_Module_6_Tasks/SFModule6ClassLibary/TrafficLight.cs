namespace SFModule6ClassLibrary
{
    public class TrafficLight
    {
        string? curcolor;

        private void ChangeColor(string color)
        {
            curcolor = color;
        }
        public string GetColor()
        {
            return curcolor;
        }
    }
}
