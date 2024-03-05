using System;
using System.Collections.Generic;

namespace MachineLearningMachine3000.Data;

public partial class DimDate
{
    public int DateId { get; set; }

    public int Jahr { get; set; }

    public string Quartal { get; set; } = null!;

    public string Monat { get; set; } = null!;

    public int Tag { get; set; }

    public string DayName { get; set; } = null!;

    public int SummeVonDayOfMonthNr { get; set; }

    public int SummeVonDayOfWeekNr { get; set; }

    public string? Holiday { get; set; }

    public string MonthName { get; set; } = null!;

    public int SummeVonMonthNr { get; set; }

    public string? AnzahlVonNextWorkDayDateId { get; set; }

    public int SummeVonQuarterNr { get; set; }

    public string QuaterName { get; set; } = null!;

    public string WeekName { get; set; } = null!;

    public int SummeVonWeekNr { get; set; }

    public string YearMonthName { get; set; } = null!;

    public int SummeVonYearNr { get; set; }

    public string YearQuater { get; set; } = null!;

    public string YearWeekName { get; set; } = null!;
}
