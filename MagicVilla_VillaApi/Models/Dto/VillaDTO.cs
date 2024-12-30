namespace MagicVilla_VillaApi.Models.Dto;

public class VillaDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Occupancy  { get; set; }
    public string Sqft  { get; set; }
    public DateOnly CreatedDate { get; set; }

}