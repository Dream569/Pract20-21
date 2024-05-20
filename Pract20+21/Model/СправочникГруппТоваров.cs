using System;
using System.Collections.Generic;

namespace Pract20_21.Model;

public partial class СправочникГруппТоваров
{
    public int КодГруппы { get; set; }

    public string НаименованиеГруппы { get; set; } = null!;

    public virtual ICollection<Ценник> Ценникs { get; set; } = new List<Ценник>();
}
