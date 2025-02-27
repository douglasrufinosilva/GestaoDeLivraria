﻿using GestaoDeLivraria.Enums;

namespace GestaoDeLivraria.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public Genders Gender { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
}
