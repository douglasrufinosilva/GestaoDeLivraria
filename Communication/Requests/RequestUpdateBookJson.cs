using GestaoDeLivraria.Enums;

namespace GestaoDeLivraria.Communication.Requests;

public class RequestUpdateBookJson
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public Genders Gender { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
}
