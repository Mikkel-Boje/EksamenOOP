using System;

namespace Stregsystemet {
    public class SeasonalProduct : Product {
        public SeasonalProduct( DateTime seasonStartDate, DateTime seasonEndDate, 
                                string name, double price, bool isActive, bool canBeBoughtOnCredit) : 
                                base(name, price, isActive, canBeBoughtOnCredit) {
            SeasonStartDate = seasonStartDate;
            SeasonEndDate = seasonEndDate;
        }
        public SeasonalProduct( DateTime seasonStartDate, DateTime seasonEndDate, 
                                int id, string name, double price, bool isActive, bool canBeBoughtOnCredit) : 
                                base(id, name, price, isActive, canBeBoughtOnCredit) {
            SeasonStartDate = seasonStartDate;
            SeasonEndDate = seasonEndDate;
        }
        public DateTime SeasonStartDate { get; init; }
        public DateTime SeasonEndDate { get; init; }
    }
}