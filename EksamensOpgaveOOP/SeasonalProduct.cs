using System;

namespace Stregsystemet {
    public class SeasonalProduct : Product {
        public SeasonalProduct( DateTime seasonStartDate, DateTime seasonEndDate, 
                                string name, double price, bool isActive) : base(name, price, isActive) {
            this.seasonStartDate = seasonStartDate;
            this.seasonEndDate = seasonEndDate;
        }
        public DateTime seasonStartDate { get; init; }
        public DateTime seasonEndDate { get; init; }
    }
}