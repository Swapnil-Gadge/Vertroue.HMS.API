using MediatR;

public class AddTpaMasterCommand : IRequest<string>
{
    public string TP_Name { get; set; }
    public string License_Number { get; set; }
    public string License_Validity { get; set; }
    public string Chief_Executive_Officer { get; set; }
    public string TPA_Address { get; set; }
    public string Senior_Citizen_Helpline { get; set; }
    public string Toll_Free_Number { get; set; }
    public string TPA_Email { get; set; }
    public string TPA_Website { get; set; }
    public int UserId { get; set; }
}
