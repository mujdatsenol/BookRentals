namespace BookRentals.Common
{
    public class WorkingDate
    {
        private static readonly HashSet<DateTime> holidays = new HashSet<DateTime>();

        public WorkingDate()
        {
            NewYear();
            RamadanFeast();
            NationalSovereigntyAndChildrensDay();
            LaborAndSolidarityDay();
            CommemorationAtatürkYouthAndSportsDay();
            SacrificeFeast();
            DemocracyDay();
            VictoryDay();
            RepublicDay();
        }

        public DateTime GetNextWorkingDay(DateTime date)
        {
            do
            {
                date = date.AddDays(1);
            }
            while (IsHoliday(date) || IsWeekend(date));

            return date;
        }

        private static bool IsHoliday(DateTime date)
        {
            return holidays.Contains(date);
        }

        private static bool IsWeekend(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday
                || date.DayOfWeek == DayOfWeek.Sunday;
        }

        /// <summary>
        /// Yeni Yıl
        /// </summary>
        private void NewYear()
        {
            holidays.Add(new DateTime(2023, 1, 1));
        }

        /// <summary>
        /// Ramazan Byayramı
        /// </summary>
        private void RamadanFeast()
        {
            //holidays.Add(new DateTime(2023, 4, 20, 12, 0, 0));
            holidays.Add(new DateTime(2023, 4, 21));
            holidays.Add(new DateTime(2023, 4, 22));
            holidays.Add(new DateTime(2023, 4, 23));
        }

        /// <summary>
        /// Ulusal Egementlik ve Çocuk Bayramı
        /// </summary>
        private void NationalSovereigntyAndChildrensDay()
        {
            holidays.Add(new DateTime(2023, 4, 23));
        }

        /// <summary>
        /// Emek ve Dayanışma Günü (İşçi Bayramı)
        /// </summary>
        private void LaborAndSolidarityDay()
        {
            holidays.Add(new DateTime(2023, 5, 1));
        }

        /// <summary>
        /// Atatürk'ü Anma, Gençlik ve Spor Bayramı
        /// </summary>
        private void CommemorationAtatürkYouthAndSportsDay()
        {
            holidays.Add(new DateTime(2023, 5, 19));
        }

        /// <summary>
        /// Kurban Bayramı
        /// </summary>
        private void SacrificeFeast()
        {
            //holidays.Add(new DateTime(2023, 6, 27, 12, 0, 0));
            holidays.Add(new DateTime(2023, 6, 28));
            holidays.Add(new DateTime(2023, 6, 29));
            holidays.Add(new DateTime(2023, 6, 30));
            holidays.Add(new DateTime(2023, 7, 1));
        }

        /// <summary>
        /// Demokrasi Günü
        /// </summary>
        private void DemocracyDay()
        {
            holidays.Add(new DateTime(2023, 7, 15));
        }

        /// <summary>
        /// Zafer Bayramı
        /// </summary>
        private void VictoryDay()
        {
            holidays.Add(new DateTime(2023, 8, 30));
        }

        /// <summary>
        /// Cumhuriyer Bayramı
        /// </summary>
        private void RepublicDay()
        {
            holidays.Add(new DateTime(2023, 10, 29));
        }
    }
}
