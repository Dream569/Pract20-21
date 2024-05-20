using System;
using System.Collections.Generic;

namespace Pract20_21.Model;

public partial class Поставщик
{
    public int КодПоставщика { get; set; }

    public int КодТовара { get; set; }

    public string Адрес { get; set; } = null!;

    public string Телефон { get; set; } = null!;

    public virtual Ценник КодТовараNavigation { get; set; } = null!;
}
