using System;
using System.Collections.Generic;

namespace MachineLearningMachine3000.Data;

public partial class VwFactCase
{
    public int DateId { get; set; }

    public int ServiceIdId { get; set; }

    public int EingangNeu { get; set; }

    public int EingangAktiv { get; set; }

    public int Jahr { get; set; }

    public string Quartal { get; set; } = null!;

    public string Monat { get; set; } = null!;

    public int Tag { get; set; }

    public string DayName { get; set; } = null!;

    public int DayOfMonthNr { get; set; }

    public int DayOfWeekNr { get; set; }

    public string? Holiday { get; set; }

    public string MonthName { get; set; } = null!;

    public int MonthNr { get; set; }

    public string? NextWorkDayDateId { get; set; }

    public int QuarterNr { get; set; }

    public string QuaterName { get; set; } = null!;

    public string WeekName { get; set; } = null!;

    public int WeekNr { get; set; }

    public string YearMonthName { get; set; } = null!;

    public int YearNr { get; set; }

    public string YearQuater { get; set; } = null!;

    public string YearWeekName { get; set; } = null!;
}
