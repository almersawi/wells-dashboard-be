namespace API.Views
{
    public class DashboardView
    {
        public int FlowingWellCount { get; set; }
        public int ShutinWellCount { get; set; }
        public int AbandonedWellCount { get; set; }
        public int ProducerWellCount { get; set; }
        public int InjectorWellCount { get; set; }
        public int SingleStringWellCount { get; set; }
        public int DualStringWellCount { get; set; }
        public double CurrentRate { get; set; }
        public string CurrentRateDate { get; set; }
        public double MaxDailyRate { get; set; }
        public string MaxDailyRateDate { get; set; }
        public double MinDailyRate { get; set; }
        public string MinDailyRateDate { get; set; }
        public double MaxWellCurrentRate { get; set; }
        public string WellWithMaxCurrentRate { get; set; }


    }
}