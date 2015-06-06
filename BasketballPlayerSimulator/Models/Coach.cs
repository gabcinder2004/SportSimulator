namespace BasketballPlayerSimulator
{
    public class Coach
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}