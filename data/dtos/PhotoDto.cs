namespace data.dtos;

public class PhotoDto
{
    public int Id { get; set; }
     public int ProcedureId {get; set; }
    public int PublicId { get; set; }
    public string Url {get; set;} = "";
    public string Description {get; set;} = "";
    public DateTime DateAdded {get; set;}
}