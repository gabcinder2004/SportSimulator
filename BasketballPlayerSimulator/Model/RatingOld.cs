namespace BasketballPlayerSimulator
{
    public class RatingOld
    {
        public int Overall { get; set; }
        public int Offense { get; set; }
        public int Defense { get; set; }
        public int ShortRange { get; set; }
        public int MediumRange { get; set; }
        public int LongRange { get; set; }

        //For Players
        public RatingOld(int overall, int offense, int defense, int shortRange, int mediumRange, int longRange)
        {
            Overall = overall;
            Offense = offense;
            Defense = defense;
            ShortRange = shortRange;
            MediumRange = mediumRange;
            LongRange = longRange;
        }

        //For Teams
        public RatingOld(int overall)
        {
            Overall = overall;
        }

        public override string ToString()
        {
            return string.Format("Overall: {0}", Overall);
        }
    }
}
