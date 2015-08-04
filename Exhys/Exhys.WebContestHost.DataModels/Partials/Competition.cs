﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exhys.WebContestHost.DataModels.Partials;

namespace Exhys.WebContestHost.DataModels
{
    public partial class Competition : IDeletable
    {
        public void DeleteFrom (ExhysContestEntities db)
        {
            this.Problems.Clear();
            db.Competitions.Remove(this);
        }
    }
}
