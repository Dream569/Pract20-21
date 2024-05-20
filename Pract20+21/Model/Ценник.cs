using System;
using System.Collections.Generic;

namespace Pract20_21.Model;

public partial class Ценник
{
    public int КодТовара { get; set; }

    public string НаименованиеТовара { get; set; } = null!;

    public int КодГруппы { get; set; }

    public string ЕдиницыИзмерения { get; set; } = null!;

    public decimal Цена { get; set; }

    public virtual СправочникГруппТоваров КодГруппыNavigation { get; set; } = null!;

    public virtual ICollection<Поставщик> Поставщикs { get; set; } = new List<Поставщик>();

    public virtual ICollection<Поступления> Поступленияs { get; set; } = new List<Поступления>();

    public virtual ICollection<Продажи> Продажиs { get; set; } = new List<Продажи>();
}
