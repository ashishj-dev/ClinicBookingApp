using System;

namespace ClinicBookingAPI;

public class AppointmentEntity
{
    public AppointmentEntity(string name, int age, GenderType sex, string condition, DateOnly date, TimeOnly startTime, int durationInMinutes)
    {
        Name = name;
        Age = age;
        Sex = sex;
        Condition = condition;
        Date = date;
        StartTime = startTime;
        DurationInMinutes = durationInMinutes;
    }

    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public GenderType Sex { get; set; }
    public string Condition { get; set; } = string.Empty;
    public string Treatment { get; set; } = string.Empty;
    public string Reference { get; set; } = string.Empty;
    public DateOnly Date { get; set; }
    public TimeOnly StartTime { get;set; }
    public TimeOnly EndTime { get; private set; }
    public int DurationInMinutes { get; set; } = 60;
    public decimal Amount { get; set; } = 0;
    public string BillNumber { get; set; } = string.Empty;
    public StatusType Status { get; set; } = StatusType.Confirmed;
    public PaymentStatusType PaymentStatus { get; set; } = PaymentStatusType.Pending;

    //to be called manaully before saving to db whenever new appointment is created
    public void CalculateEndTime()
    {
        EndTime = StartTime.AddMinutes(DurationInMinutes);
    }


}
